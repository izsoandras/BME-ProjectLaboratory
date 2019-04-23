using System;
using RoboPro.Utils;

namespace RoboPro.ServerAgents
{
    public delegate void OnMessageDelegate(string message);

    public abstract class AbstractAgent
    {
        protected Logger logger;

        public event OnMessageDelegate OnMessage;

        public AbstractAgent(Logger lg)
        {
            logger = lg;
        }

        public bool IsOpen { get; }

        public abstract void SendMessage(string message);

        public abstract void Connect(string location);

        public abstract void Close();

        public abstract void HandleKey(char key, char dir);

        protected void RaiseOnMessage(string msg)
        {
            if (OnMessage != null)
                OnMessage(msg);
        }

    }
}
