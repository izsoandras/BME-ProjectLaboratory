
using System.Net;
using System.Windows.Forms;
using WebSocketSharp;

namespace RoboPro.ServerAgents
{
    public class WebSocketAgent : AbstractAgent
    {
        /// <summary>
        /// Delegate to handel the WebSocket events
        /// </summary>
        /// <param name="opensender">The opensender.</param>
        /// <param name="evt">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public delegate void WSEvent(object opensender, System.EventArgs evt);
        /// <summary>
        /// Hook point for what to do when we connect to a WebSocket server
        /// </summary>
        public WSEvent OnOpen;
        /// <summary>
        /// Hook point for what to do when we disconnect from a WebSocket server
        /// </summary>
        public WSEvent OnClose;

        /// <summary>
        /// The WebSocket object, which represents the connection to the robot's WebSocket server.
        /// </summary>
        private WebSocket ws;

        /// <summary>
        /// Gets a value indicating whether this WebSocket connection is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen
        {
            get
            {
                return ws == null ? false : ws.IsAlive; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebSocketAgent"/> class.
        /// </summary>
        /// <param name="lg">The lg.</param>
        public WebSocketAgent(Utils.Logger lg):base(lg)
        {
        }

        /// <summary>
        /// Wrapper function to send the message to the WebSocket server and also log it
        /// </summary>
        /// <param name="msg"></param>
        public override void SendMessage(string msg)
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
        /// Connects to the WebSocket server.
        /// </summary>
        /// <param name="location">The URL address of the WebSocket server.</param>
        public override void Connect(string location)
        {
            //Instantiate the WebSocket object and subscribe the listeners
            //Add the hookpoints of the wrapper class
            ws = new WebSocket(location);
            ws.OnOpen += (opensender, evt) => { //Log the event
                logger.LogMsg("Connected to WebSocet server: " + ws.Url.ToString());
                OnOpen(opensender, evt);
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
                OnClose(opensender, evt);
            };
           
            ws.OnMessage += (opensender, evt) =>
            {
                //Log the event
                WebSocketSharp.MessageEventArgs msge = (WebSocketSharp.MessageEventArgs)evt;
                logger.LogMsg(ws.Url.ToString() + "> " + msge.Data);
                RaiseOnMessage(msge.Data);
            };
            ws.Connect();
        }
        /// <summary>
        /// Closes this WebSocket connection.
        /// </summary>
        public override void Close()
        {
            ws.Close();
        }
        /// <summary>
        /// Sends the message about the key event to the server.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dir">The dir.</param>
        public override void HandleKey(char key, char dir)
        {
            //Send the message
            SendMessage($"KB:{key},{dir}");
        }


    }
}
