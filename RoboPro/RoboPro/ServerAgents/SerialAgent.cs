using System.IO.Ports;

namespace RoboPro.ServerAgents
{
    public class SerialAgent : AbstractAgent
    {
        /// <summary>
        /// The COM port of the robot if we connect it directly
        /// </summary>
        private SerialPort port;
        /// <summary>
        /// Enumeration for easier determination of motor direction
        /// </summary>
        private enum Acceleration
        {
            Forward = 1,
            None = 0,
            Backward = -1
        }
        /// <summary>
        /// Enumeration for easier determination of robot direction
        /// </summary>
        private enum Steering
        {
            Left = 1,
            None = 0,
            Right = -1
        }

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
        /// <summary>
        /// Initializes a new instance of the <see cref="SerialAgent"/> class.
        /// </summary>
        /// <param name="lg">The lg.</param>
        public SerialAgent(Utils.Logger lg) : base(lg)
        {
            port = new SerialPort();
        }
        /// <summary>
        /// Sends the message through serial.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void SendMessage(string message)
        {
            if (port != null && port.IsOpen)
            {
                port.WriteLine(message);
                logger.LogMsg("Serial message sent: " + message);
            }
        }
        /// <summary>
        /// Gets a value indicating whether this serial connection is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen
        {
            get { return port.IsOpen; }
        }
        /// <summary>
        /// Open the serial port.
        /// </summary>
        /// <param name="location">The name of the COM port.</param>
        public override void Connect(string location)
        {
            port.PortName = location;
            port.BaudRate = 115200;
            //port = new SerialPort(location, 115200);
            port.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
            port.Open();

            logger.LogMsg("Serial port " + port.PortName + " is open");
        }
        /// <summary>
        /// Handles the DataReceived event of the serial control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SerialDataReceivedEventArgs"/> instance containing the event data.</param>
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (port.BytesToRead > 0)
            {
                string msg = port.ReadLine();
                logger.LogMsg(port.PortName + "> " + msg);
                RaiseOnMessage(msg);
            }
        }
        /// <summary>
        /// Closes the serial port.
        /// </summary>
        public override void Close()
        {
            port.Close();
            logger.LogMsg("Serial port " + port.PortName + "is closed");
        }
        /// <summary>
        /// Decides what to do when a key is pressed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dir">The dir.</param>
        public override void HandleKey(char key, char dir)
        {
            if (port != null && port.IsOpen)
            {
                //updates the keystates according to the event
                switch (key)
                {
                    case 'W':
                        keyStates[(int)MyKeys.Wkey] = dir == 'D';
                        break;
                    case 'A':
                        keyStates[(int)MyKeys.Akey] = dir == 'D';
                        break;
                    case 'S':
                        keyStates[(int)MyKeys.Skey] = dir == 'D';
                        break;
                    case 'D':
                        keyStates[(int)MyKeys.Dkey] = dir == 'D';
                        break;
                    default:
                        return;
                }

                int accel;
                int steer;
                //calculates the acceleration value based on the keystates
                //Forward: only W is pressed
                //Backward: only S is pressed
                //None: both or neither W and S is pressed
                if (keyStates[(int)MyKeys.Wkey] == keyStates[(int)MyKeys.Skey])
                    accel = (int)Acceleration.None;
                else if (keyStates[(int)MyKeys.Wkey])
                    accel = (int)Acceleration.Forward;
                else
                    accel = (int)Acceleration.Backward;
                //Calculates the steering direction
                //Left: only A is pressed
                //Right: only D is pressed
                //None: both or neither A and D is pressed
                if (keyStates[(int)MyKeys.Akey] == keyStates[(int)MyKeys.Dkey])
                    steer = (int)Steering.None;
                else if (keyStates[(int)MyKeys.Akey])
                    steer = (int)Steering.Left;
                else
                    steer = (int)Steering.Right;

                //Put together the message and send it
                if (accel == 0)
                {
                    SendMessage($"S:{-60 * steer},{60 * steer}");
                }
                else
                {
                    SendMessage($"S:{accel * (60 - 5 * steer)},{accel * (60 + 5 * steer)}");
                }
            }
        }
    }
}
