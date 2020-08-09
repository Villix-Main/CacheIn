using System;

namespace Villix.CacheIn.Core.Exceptions
{
    public class AddDuringPausedQueueException : Exception
    {

        #region Private Members

        /// <summary>
        /// The message to explain the thrown exception
        /// </summary>
        private string mMessage;

        #endregion

        #region Public Properties

        /// <summary>
        /// The message to explain the thrown exception
        /// </summary>
        public override string Message => mMessage;

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddDuringPausedQueueException()
        {
            // Set default exception message
            mMessage = "Items cannot be added to the queue collection when the queue cycle is paused";
        }

        /// <summary>
        /// Constructor to take in custom exception message
        /// </summary>
        /// <param name="message">The custom exception message</param>
        public AddDuringPausedQueueException(string message)
        {
            // Set custom exception message
            mMessage = message;
        }
    }
}
