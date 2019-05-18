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
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using RoboPro.ServerAgents;
using RoboPro.Utils;
using WebSocketSharp;

namespace RoboPro
{


    /// <summary>
    /// The inherited class from Windows.Forms.Form, which is needed to make our own
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class robotClientForm : Form
    {
        /// <summary>
        ///Delegate for handling the key events which are interesting for us
        /// </summary>
        /// <param name="key">The character of the key</param>
        /// <param name="dir">Up or Down</param>
        private delegate void HandledKeyListener(char key, char dir);
        /// <summary>
        /// The event called when an interesting key event is performed
        /// </summary>
        private event HandledKeyListener HandledKeyEvent;

        /// <summary>
        /// The video stream from the camera of the robot
        /// </summary>
        private MJPEGStream videoStream;

        /// <summary>
        /// The logger, which logs messages to all subscribed places. 
        /// The <c>Logger.Log</c> event is fired when the <c>Logger.LogMsg</c> method is called.
        /// </summary>
        private Utils.Logger logger = new Utils.Logger();

        /// <summary>
        /// Proxy object to handle serial connection
        /// </summary>
        private SerialAgent serial;

        /// <summary>
        /// Proxy object to handle serial connection
        /// </summary>
        private WebSocketAgent webSocket;

        /// <summary>
        /// Keys for WASD control of the robot
        /// </summary>
        private enum MyKeys
        {
            Wkey = 0,
            Akey = 1,
            Skey = 2,
            Dkey = 3
        };
        /// <summary>
        /// The state of the 4 keys used for control
        /// </summary>
        bool[] keyStates = new bool[4] { false, false, false, false };

        private List<float> tempData = new List<float>(new float[]{24,24,24,24,24});

        private List<float> humidData = new List<float>(new float[] { 30,30,30,30,30});

        private List<float> pressData = new List<float>(new float[] { 100000, 100000, 100000, 100000, 100000});

        /// <summary>
        /// Initializes a new instance of the <see cref="robotClientForm"/> class.
        /// After the auto generated initialization we check if there are previous values to load, and subscribe the loggers.
        /// </summary>
        public robotClientForm()
        {
            InitializeComponent();

            //Load previous addresses
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

            //initialize the logger
            logger.Log += LogToConsole;

            //initialize the proxy objects
            webSocket = new WebSocketAgent(logger);
            serial = new SerialAgent(logger);

            //define what to when the websocket is connected
            webSocket.OnOpen += (opensender, evt) =>
            {
                {
                    //Save the input
                    SaveInputs();

                    //Enables the controls' for message sending
                    SetEnableWSMessage(true);

                    //Change the button's behaviour to disconnect
                    btnWSConnect.Text = "Disconnect";
                    btnWSConnect.Click -= btnWSConnect_Click;
                    btnWSConnect.Click += btnWSDisconnect_Click;
                    HandledKeyEvent += webSocket.HandleKey;
                    tbWSAddress.Enabled = false;
                };
            };

            //define what to when the websocket is closed
            webSocket.OnClose += (opensender, evt) =>
            {
                {

                    SetEnableWSMessage(false);


                    //Change the button's behaviour
                    btnWSConnect.Text = "Connect";
                    btnWSConnect.Click -= btnWSDisconnect_Click;
                    btnWSConnect.Click += btnWSConnect_Click;
                    HandledKeyEvent -= webSocket.HandleKey;
                    tbWSAddress.Enabled = true;
                }
                ;

               
            };

            webSocket.OnMessage += IncomingSensorData;
            serial.OnMessage += IncomingSensorData;

            //placeholder data
            chartHumid.Series["Humid"].Points.Clear();
            chartTemp.Series["Temp"].Points.Clear();
            chartPress.Series["Press"].Points.Clear();
            for (int i = 0; i < 5; i++)
            {
                chartHumid.Series["Humid"].Points.AddXY(i, humidData[i]);
                chartTemp.Series["Temp"].Points.AddXY(i, tempData[i]);
                chartPress.Series["Press"].Points.AddXY(i, pressData[i]);
            }
            chartHumid.Invalidate();
            chartTemp.Invalidate();
            chartPress.Invalidate();
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
        private void btnStreamConnect_Click(object sender, EventArgs e)
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
                btnStreamConnect.Text = "Disconnect";
                tbCamAddress.Enabled = false;
                btnStreamConnect.Click -= btnStreamConnect_Click;
                btnStreamConnect.Click += btnStreamDisconnect_Click;
            }
        }
        /// <summary>
        /// Handles the Click event of the btnConnect control.
        /// This event handler is used when the streaming is in progress.
        /// It stops the streaming, logs the event and changes the button's behaviour to connect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStreamDisconnect_Click(object sender, EventArgs e)
        {
            //Stop the stream
            videoStream.Stop();

            //Log the event
            logger.LogMsg("Disconnected");

            //Change the button's behaviour
            btnStreamConnect.Text = "Connect";
            tbCamAddress.Enabled = true;
            btnStreamConnect.Click -= btnStreamDisconnect_Click;
            btnStreamConnect.Click += btnStreamConnect_Click;
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
            if (webSocket.IsOpen)
                webSocket.Close();
            if (serial.IsOpen)
                serial.Close();
        }
        /// <summary>
        /// Enables/disables the controls connected to the WebSocket message sending functionality.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        private delegate void SetEnableWSMessageDelegate(bool enabled);
        /// <summary>
        /// Enable the controls which are used for sending the WebSocket message
        /// </summary>
        /// <param name="enabled"></param>
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
            webSocket.Connect(tbWSAddress.Text);
        }
        /// <summary>
        /// Handles the Click event of the btnWSDisconnect control.
        /// Close the WebSocket connection and change the button's behaviour to connect
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWSDisconnect_Click(object sender, EventArgs e)
        {
            webSocket.Close();
        }
        /// <summary>
        /// Handles the Click event of the btnWSSend control.
        /// Sends the message typed in the tbWSSend textbox and logs the event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnWSSend_Click(object sender, EventArgs e)
        {
            webSocket.SendMessage(tbWSSend.Text);
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
                HandledKeyEvent?.Invoke('W', 'U');
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


        /// <summary>
        /// Handles the Click event of the btnSerial control, when connection is not open.
        /// Open the serial port and change the controls
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSerialOpen_Click(object sender, EventArgs e)
        {
            serial.Connect(tbCOMport.Text);
            if (serial.IsOpen)
            {
                SaveInputs();
                btnSerialOpen.Click -= btnSerialOpen_Click;
                btnSerialOpen.Click += btnSerialClose_Click;
                HandledKeyEvent += serial.HandleKey;
                btnSerialOpen.Text = "Close";
                tbSerialSend.Enabled = true;
                btnSerialSend.Enabled = true;
            }
        }


        /// <summary>
        /// Handles the Click event of the btnSerial control, when connection is open.
        /// Close the connection and change the controls.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSerialClose_Click(object sender, EventArgs e)
        {
            serial.Close();
            btnSerialOpen.Click -= btnSerialClose_Click;
            btnSerialOpen.Click += btnSerialOpen_Click;
            HandledKeyEvent -= serial.HandleKey;
            btnSerialOpen.Text = "Open";
            tbSerialSend.Enabled = false;
            btnSerialSend.Enabled = false;
        }
        /// <summary>
        /// Handles the Click event of the btnSerialSend control.
        /// Send the input through the serial port.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSerialSend_Click(object sender, EventArgs e)
        {
            serial.SendMessage(tbSerialSend.Text);
        }

        /// <summary>
        /// Saves the addresses so you don't have to type them in next time
        /// </summary>
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
        /// <summary>
        /// Removes the key events when entering a textbox, so it's not triggered when typing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tb_Enter_removeKeyListeners(object sender, EventArgs e)
        {
            KeyDown -= robotClientForm_KeyDown;
            KeyUp -= robotClientForm_KeyUp;
        }
        /// <summary>
        /// Adds the key events when leaving a textbox, so you can control the robot with them.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tb_Leave_addKeyListeners(object sender, EventArgs e)
        {
            KeyDown += robotClientForm_KeyDown;
            KeyUp += robotClientForm_KeyUp;
        }
        /// <summary>
        /// Sends the values to the robot.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Turn off the motors
            webSocket.SendMessage("SR:S:0,0");
            //Set the pwm
            webSocket.SendMessage($"SR:F:{nudPWMfreq.Value}");
            //Set the speed
            webSocket.SendMessage($"SR:S:{nudDutyLeft.Value},{nudDutyRight.Value}");
        }

        private void tabViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabViews.SelectedIndex == 0)
            {
                if (videoStream != null)
                {
                    videoStream.Start();
                }

                timerSensor.Enabled = false;
            }
            else
            {
                timerSensor.Enabled = true;
                if (videoStream != null)
                    videoStream.Stop();
            }
        }

        private void timerSensor_Tick(object sender, EventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.SendMessage("M:");
                Thread.Sleep(100);
                serial.SendMessage("T:");
                Thread.Sleep(100);
                serial.SendMessage("H:");
                Thread.Sleep(100);
                serial.SendMessage("P:");
                Thread.Sleep(100);
            }
            if (webSocket.IsOpen)
            {
                webSocket.SendMessage("SR:M:");
                webSocket.SendMessage("SR:T:");
                webSocket.SendMessage("SR:H:");
                webSocket.SendMessage("SR:P:");
            }
        }

        private void IncomingSensorData(string msg)
        {
            if (msg[1] != ':')
                return;
            string type = msg.Split(':')[0];
            string[] payload = msg.Split(':')[1].Split(',');
            switch (type)
            {
                case "M":
                    compass.Heading = new PointF(float.Parse(payload[0]), float.Parse(payload[1]));
                    break;
                case "H":
                    humidData.RemoveAt(0);
                    humidData.Add(float.Parse(payload[0]));
                    updateChart(chartHumid, humidData);
                    /*
                    chartHumid.Series["Humid"].Points.Clear();
                    for (int i = 0; i < 5; i++)
                        chartHumid.Series["Humid"].Points.AddXY(i, humidData[i]);

                    chartHumid.Invalidate();*/
                    break;
                case "T":
                    tempData.RemoveAt(0);
                    tempData.Add(float.Parse(payload[0]));
                    updateChart(chartTemp, tempData);
                    /*
                    chartTemp.Series["Temp"].Points.Clear();
                    for (int i = 0; i < 5; i++)
                        chartTemp.Series["Temp"].Points.AddXY(i, tempData[i]);

                    chartTemp.Invalidate();*/
                    break;
                case "P":
                    pressData.RemoveAt(0);
                    pressData.Add(float.Parse(payload[0]));
                    updateChart(chartPress, pressData);
                    /*
                    chartPress.Series["Press"].Points.Clear();
                    for (int i = 0; i < 5; i++)
                        chartPress.Series["Press"].Points.AddXY(i, pressData[i]);

                    chartPress.Invalidate();*/
                    break;
                default:
                    break;
            }
        }

        private delegate void chartupdatedelegate(Chart updateable, List<float> dataset);
        private void updateChart(Chart updateable, List<float> dataset)
        {
            if (updateable.InvokeRequired)
            {
                chartupdatedelegate d = new chartupdatedelegate(updateChart);
                updateable.Invoke(d, new object[]{updateable,dataset});
            }
            else
            {
                updateable.Series[0].Points.Clear();
                for (int i = 0; i < 5; i++)
                    updateable.Series[0].Points.AddXY(i, dataset[i]);
                updateable.Invalidate();
            }
        }
    }
}
