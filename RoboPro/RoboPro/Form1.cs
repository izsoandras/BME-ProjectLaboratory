using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using System.IO;
using WebSocketSharp;

namespace RoboPro
{
    /// <summary>
    /// The inherited class from Windows.Forms.Form, which needed to make our own
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class robotClientForm : Form
    {
        /// <summary>
        /// The video stream from the camera of the robot
        /// </summary>
        MJPEGStream videoStream;
        /// <summary>
        /// The logger, which logs messages to all subscribed places. 
        /// The <c>Logger.Log</c> event is fired when the <c>Logger.LogMsg</c> method is called.
        /// </summary>
        Utils.Logger logger;
        /// <summary>
        /// The WebSocket object, which represents the connection to the robot's WebSocket server.
        /// </summary>
        WebSocket ws;
        /// <summary>
        /// Initializes a new instance of the <see cref="robotClientForm"/> class.
        /// After the auto generated initialization we check if there are previous values to load, and subscribe the loggers.
        /// </summary>
        public robotClientForm()
        {
            InitializeComponent();

            FileInfo ipFile = new FileInfo("lastvalues.txt");

            if (ipFile.Exists)
            {
                using (StreamReader sw = new StreamReader(ipFile.FullName))
                {
                    tbCamAddress.Text = sw.ReadLine();
                    tbWSAddress.Text = sw.ReadLine();
                }
            }
            logger = new Utils.Logger();
             logger.Log += LogToConsole;
        }
        /// <summary>
        /// Logs to the application's console.
        /// </summary>
        /// <param name="msg">The message to be logged.</param>
        private void LogToConsole(string msg)
        {
            //If we aren't on the GUI thread we need to use invoke
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Utils.LogHandler(LogToConsole), msg + "\n");
                }
                catch (ObjectDisposedException) { }
            }
            else
            {
                tbConsole.AppendText(msg + "\n");
            }
        }
        /// <summary>
        /// Handles the Click event of the btnConnect control.
        /// Starts the video stream and changes the button's behaviour to disconnect.
        /// Also saves the URL input so it can be reloaded after restart.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Starting the stream
            videoStream = new MJPEGStream(tbCamAddress.Text);
            videoStream.NewFrame += videoStream_NewFrame;
            videoStream.Start();

            //TODO: URL, stream validation

            //Save the input
            FileInfo ipFile = new FileInfo("lastvalues.txt");
            using (StreamWriter sw = new StreamWriter(ipFile.FullName))
            {
                sw.WriteLine(tbCamAddress.Text);
                sw.WriteLine(tbWSAddress.Text);
            }

            //Log the event
            logger.LogMsg("Connected to: " + tbCamAddress.Text);

            //Change the button's behaviour
            btnConnect.Text = "Disconnect";
            tbCamAddress.Enabled = false;
            btnConnect.Click -= btnConnect_Click;
            btnConnect.Click += btnDisconnect_Click;
        }
        /// <summary>
        /// Handles the Click event of the btnConnect control.
        /// This event handler is used when the streaming is in progress.
        /// It stops the streaming, logs the event and changes the button's behaviour to connect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //Stop the stream
            videoStream.Stop();

            //Log the event
            logger.LogMsg("Disconnected");

            //Change the button's behaviour
            btnConnect.Text = "Connect";
            tbCamAddress.Enabled = true;
            btnConnect.Click -= btnDisconnect_Click;
            btnConnect.Click += btnConnect_Click;
        }
        /// <summary>
        /// Handles the NewFrame event of the videoStream control.
        /// It prints out the new frame on the pbCameraView
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">The <see cref="NewFrameEventArgs"/> instance containing the event data.</param>
        private void videoStream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbCameraView.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        /// <summary>
        /// Handles the FormClosing event of the robotClientForm control.
        /// It closes the costly resources if it hasn't been done yet.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void robotClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(videoStream != null)
                videoStream.Stop();
            if (ws != null)
                ws.Close();
        }
        /// <summary>
        /// Enables/disables the controls connected to the WebSocket message sending functionality.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        private delegate void SetEnableWSMessageDelegate(bool enabled);
        private void SetEnableWSMessage(bool enabled)
        {
            //If we aren't on the GUI thread we need to use invoke
            if (InvokeRequired)
            {
                Invoke(new SetEnableWSMessageDelegate(SetEnableWSMessage), enabled);
            }
            else
            {
                btnWSSend.Enabled = enabled;
                tbWSSend.Enabled = enabled;
            }
        }
        /// <summary>
        /// Handles the Click event of the btnWSConnect control.
        /// Creates the instance of the <see cref="WebSocket"/> class and sets the event listeners for it.
        /// 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWSConnect_Click(object sender, EventArgs e)
        {
            //Instantiate the WebSocket object and subscribe the listeners
            ws = new WebSocket(tbWSAddress.Text);
            ws.OnOpen += (opensender, evt) =>
            {
                //Log the event
                logger.LogMsg("Connected to WebSocet server: " + tbWSAddress.Text);

                //Save the input
                FileInfo ipFile = new FileInfo("lastvalues.txt");
                using (StreamWriter sw = new StreamWriter(ipFile.FullName))
                {
                    sw.WriteLine(tbCamAddress.Text);
                    sw.WriteLine(tbWSAddress.Text);
                }
                //Enables the controls' for message sending
                SetEnableWSMessage(true);
            };
            ws.OnError += (opensender, evt) =>
            {
                //Log the event
                WebSocketSharp.ErrorEventArgs errorarg = (WebSocketSharp.ErrorEventArgs)evt;
                logger.LogMsg("WebSocket error: " + errorarg.Message);
            };
            ws.OnClose += (opensender, evt) =>
            {
                //Log the event
                logger.LogMsg("Disconnected from WebSocet server");
                SetEnableWSMessage(false);
            };
            ws.OnMessage += (opensender, evt) =>
            {
                //Log the event
                WebSocketSharp.MessageEventArgs msge = (WebSocketSharp.MessageEventArgs)evt;
                logger.LogMsg("WebSocket message arrived: " + msge.Data);
            };
            ws.Connect();


            // TODO put it in the OnOpen event
            //Change the button's behaviour to disconnect
            btnWSConnect.Text = "Disconnect";
            btnWSConnect.Click -= btnWSConnect_Click;
            btnWSConnect.Click += btnWSDisconnect_Click;
            tbWSAddress.Enabled = false;
        }
        /// <summary>
        /// Handles the Click event of the btnWSDisconnect control.
        /// Close the WebSocket connection and change the button's behaviour to connect
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWSDisconnect_Click(object sender, EventArgs e)
        {
            //Close the connection
            ws.Close();

            //Change the button's behaviour
            btnWSConnect.Text = "Connect";
            btnWSConnect.Click -= btnWSDisconnect_Click;
            btnWSConnect.Click += btnWSConnect_Click;
            tbWSAddress.Enabled = true;
        }
        /// <summary>
        /// Handles the Click event of the btnWSSend control.
        /// Sends the message typed in the tbWSSend textbox and logs the event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWSSend_Click(object sender, EventArgs e)
        {
            //Sends the message
            ws.Send(tbWSSend.Text);
            //Logs the event.
            logger.LogMsg("WebSocket message sent: " + tbWSSend.Text);
        }
    }
}
