using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Additional classes to make the functioning of the application easier
/// </summary>
namespace RoboPro.Utils
{
    /// <summary>
    /// Delegate for the Log event.
    /// </summary>
    /// <param name="msg">The message to be sent.</param>
    public delegate void LogHandler(string msg);
    /// <summary>
    /// The logger class. This class is responsible for logging the messages to all the different destinations.
    /// </summary>
    class Logger
    {
        /// <summary>
        /// Log destinations have to subscribe for this event.
        /// </summary>
        public event LogHandler Log;
        /// <summary>
        /// Method to be called when a messages is needed to be logged.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void LogMsg(String msg)
        {
            if (Log != null)
                Log(msg);
        }
    }
}
