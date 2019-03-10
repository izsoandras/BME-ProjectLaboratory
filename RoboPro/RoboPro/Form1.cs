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
using System.IO.Ports;
using System.Runtime.CompilerServices;
using WebSocketSharp;

namespace RoboPro
{


    /// <summary>
    /// The inherited class from Windows.Forms.Form, which needed to make our own
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class robotClientForm : Form
    {
        private delegate void HandledKeyListener(char key, char dir);

        private event HandledKeyListener HandledKeyEvent;

        private enum MyKeys
        {
            Wkey = 0,
            Akey = 1,
            Skey = 2,
            Dkey = 3
        };

        bool[] keyStates = new bool[4] { false, false, false, false };

        /// <summary>
        /// The video stream from the camera of the robot
        /// </summary>
        private MJPEGStream videoStream;

        /// <summary>
        /// The logger, which logs messages to all subscribed places. 
        /// The <c>Logger.Log</c> event is fired when the <c>Logger.LogMsg</c> method is called.
        /// </summary>
        private Utils.Logger logger;

        /// <summary>
        /// The WebSocket object, which represents the connection to the robot's WebSocket server.
        /// </summary>
        private WebSocket ws;

        private SerialPort port;


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
                    tbCOMport.Text = sw.ReadLine();
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

        private void SendWSmessage(string msg)
        {
            if (ws != null)
            {
                //Sends the message
                ws.Send(msg);
                //Logs the event.
                logger.LogMsg("WebSocket message sent: " + msg);
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
            if (videoStream.IsRunning)
            {
                SaveInputs();

                //Log the event
                logger.LogMsg("Connected to: " + tbCamAddress.Text);

                //Change the button's behaviour
                btnConnect.Text = "Disconnect";
                tbCamAddress.Enabled = false;
                btnConnect.Click -= btnConnect_Click;
                btnConnect.Click += btnDisconnect_Click;
            }
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
            if (videoStream != null)
                videoStream.Stop();
            if (ws != null)
                ws.Close();
            if (port != null)
                port.Close();
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
                SaveInputs();
                
                //Enables the controls' for message sending
                SetEnableWSMessage(true);

                //Change the button's behaviour to disconnect
                btnWSConnect.Text = "Disconnect";
                btnWSConnect.Click -= btnWSConnect_Click;
                btnWSConnect.Click += btnWSDisconnect_Click;
                HandledKeyEvent += HandleKey_WS;
                tbWSAddress.Enabled = false;
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


                //Change the button's behaviour
                btnWSConnect.Text = "Connect";
                btnWSConnect.Click -= btnWSDisconnect_Click;
                btnWSConnect.Click += btnWSConnect_Click;
                HandledKeyEvent -= HandleKey_WS;
                tbWSAddress.Enabled = true;
            };
            ws.OnMessage += (opensender, evt) =>
            {
                //Log the event
                WebSocketSharp.MessageEventArgs msge = (WebSocketSharp.MessageEventArgs)evt;
                logger.LogMsg(ws.Url.ToString() + "> " + msge.Data);
            };
            ws.Connect();
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
        }
        /// <summary>
        /// Handles the Click event of the btnWSSend control.
        /// Sends the message typed in the tbWSSend textbox and logs the event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWSSend_Click(object sender, EventArgs e)
        {
            //Send the message
            SendWSmessage(tbWSSend.Text);
        }

        private void HandleKey_WS(char key, char dir)
        {
            //Send the message
            SendWSmessage($"KB:{key},{dir}");
        }
        
        /// <summary>
        /// The function which sends the pressed key to the robot through WebSocket. Only WASD keys are listened
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void robotClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && !keyStates[(int)MyKeys.Wkey])
            {
                logger.LogMsg("Key down: W");
                keyStates[(int)MyKeys.Wkey] = true;
                if(HandledKeyEvent != null)
                    HandledKeyEvent('W', 'D');
            }
            else if (e.KeyCode == Keys.A && !keyStates[(int)MyKeys.Akey])
            {
                logger.LogMsg("Key down: A");
                keyStates[(int)MyKeys.Akey] = true;
                if (HandledKeyEvent != null)
                    HandledKeyEvent('A', 'D');
            }
            else if (e.KeyCode == Keys.S && !keyStates[(int)MyKeys.Skey])
            {
                logger.LogMsg("Key down: S");
                keyStates[(int)MyKeys.Skey] = true;
                if (HandledKeyEvent != null)
                    HandledKeyEvent('S', 'D');
            }
            else if (e.KeyCode == Keys.D && !keyStates[(int)MyKeys.Dkey])
            {
                logger.LogMsg("Key down: D");
                keyStates[(int)MyKeys.Dkey] = true;
                if (HandledKeyEvent != null)
                    HandledKeyEvent('D', 'D');
            }
            else if (e.KeyCode == Keys.Add)
            {
                logger.LogMsg("Key down: +");
                if (HandledKeyEvent != null)
                    HandledKeyEvent('+', 'D');
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                logger.LogMsg("Key down: -");
                if (HandledKeyEvent != null)
                    HandledKeyEvent('-', 'D');
            }
        }
        /// <summary>
        /// The function which sends the released key to the robot through WebSocket. Only WASD keys are listened
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void robotClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                logger.LogMsg("Key up: W");
                keyStates[(int)MyKeys.Wkey] = false;
                if (HandledKeyEvent != null)
                    HandledKeyEvent('W', 'U');
            }
            else if (e.KeyCode == Keys.A)
            {
                logger.LogMsg("Key up: A");
                keyStates[(int)MyKeys.Akey] = false;
                if (HandledKeyEvent != null)
                    HandledKeyEvent('A', 'U');
            }
            else if (e.KeyCode == Keys.S)
            {
                logger.LogMsg("Key up: S");
                keyStates[(int)MyKeys.Skey] = false;
                if (HandledKeyEvent != null)
                    HandledKeyEvent('S', 'U');
            }
            else if (e.KeyCode == Keys.D)
            {
                logger.LogMsg("Key up: D");
                keyStates[(int)MyKeys.Dkey] = false;
                if (HandledKeyEvent != null)
                    HandledKeyEvent('D', 'U');
            }

        }



        private void btnSerialOpen_Click(object sender, EventArgs e)
        {
            port = new SerialPort(tbCOMport.Text, 115200);
            port.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
            port.Open();
            if (port.IsOpen)
            {
                SaveInputs();
                btnSerialOpen.Click -= btnSerialOpen_Click;
                btnSerialOpen.Click += btnSerialClose_Click;
                HandledKeyEvent += HandleKey_Serial;
                btnSerialOpen.Text = "Close";
                tbSerialSend.Enabled = true;
                btnSerialSend.Enabled = true;
                logger.LogMsg("Serial port " + port.PortName + " is open");
            }
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (port.BytesToRead > 0)
            {
                logger.LogMsg(port.PortName + "> " + port.ReadLine());
            }
        }

        private void btnSerialClose_Click(object sender, EventArgs e)
        {
            port.Close();
            btnSerialOpen.Click -= btnSerialClose_Click;
            btnSerialOpen.Click += btnSerialOpen_Click;
            HandledKeyEvent -= HandleKey_Serial;
            btnSerialOpen.Text = "Open";
            tbSerialSend.Enabled = false;
            btnSerialSend.Enabled = false;
            logger.LogMsg("Serial port " + port.PortName + "is closed");
        }

        private void btnSerialSend_Click(object sender, EventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.WriteLine(tbSerialSend.Text);
            }
        }

        private enum Acceleration
        {
            Forward = 1,
            None = 0,
            Backward = -1
        }
        private enum Steering
        {
            Left = 1,
            None = 0,
            Right = -1
        }

        private void HandleKey_Serial(char key, char dir)
        {
            if (port != null && port.IsOpen)
            {
                int accel;
                int steer;
                if (keyStates[(int)MyKeys.Wkey] == keyStates[(int)MyKeys.Skey])
                    accel = (int)Acceleration.None;
                else if (keyStates[(int)MyKeys.Wkey])
                    accel = (int)Acceleration.Forward;
                else
                    accel = (int)Acceleration.Backward;

                if (keyStates[(int)MyKeys.Akey] == keyStates[(int)MyKeys.Dkey])
                    steer = (int)Steering.None;
                else if (keyStates[(int)MyKeys.Akey])
                    steer = (int)Steering.Left;
                else
                    steer = (int)Steering.Right;

                string msg;
                if (accel == 0)
                {
                    msg = $"S:{-40 * steer},{40 * steer}";
                    port.WriteLine(msg);
                }
                else
                {
                    msg = $"S:{accel * (40 - 5 * steer)},{accel * (40 + 5 * steer)}";
                    port.WriteLine(msg);
                }
                logger.LogMsg("Serial message sent: " + msg);
            }

        }

        private void SaveInputs()
        {
            FileInfo ipFile = new FileInfo("lastvalues.txt");
            using (StreamWriter sw = new StreamWriter(ipFile.FullName))
            {
                sw.WriteLine(tbCamAddress.Text);
                sw.WriteLine(tbWSAddress.Text);
                sw.WriteLine(tbCOMport.Text);
            }
        }

        private void tb_Enter_removeKeyListeners(object sender, EventArgs e)
        {
            KeyDown -= robotClientForm_KeyDown;
            KeyUp -= robotClientForm_KeyUp;
        }

        private void tb_Leave_addKeyListeners(object sender, EventArgs e)
        {
            KeyDown += robotClientForm_KeyDown;
            KeyUp += robotClientForm_KeyUp;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Turn off the motors
            SendWSmessage("SR:S:0,0");
            //Set the pwm
            SendWSmessage($"SR:P:{nudPWMfreq.Value}");
            //Set the speed
            SendWSmessage($"SR:S:{nudDutyLeft.Value},{nudDutyRight.Value}");
        }
    }
}
