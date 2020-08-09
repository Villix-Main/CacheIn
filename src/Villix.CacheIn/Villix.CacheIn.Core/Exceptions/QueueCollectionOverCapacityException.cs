using System;

namespace Villix.CacheIn.Core.Exceptions
{
    /// <summary>
    /// Exception to be thrown when the queue collection
    /// is over range of the queue collection Capacity
    /// </summary>
    public class QueueCollectionOverCapacityException : Exception
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
        public QueueCollectionOverCapacityException()
        {
            // Set default exception message
            mMessage = "Queue Collection Cannot Be Over Queue Collection Max Capacity";
        }

        /// <summary>
        /// Constructor to take in custom exception message
        /// </summary>
        /// <param name="message">The custom exception message</param>
        public QueueCollectionOverCapacityException(string message)
        {
            // Set custom exception message
            mMessage = message;
        }
    }
}
