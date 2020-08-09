using System.Threading.Tasks;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// The queue cycle of an queue collection
    /// </summary>
    public class QueueCycle
    {
        #region Private Members

        /// <summary>
        /// The status of the cycle status
        /// </summary>
        private bool mCycleStatus = true;

        #endregion

        #region Public Properties

        /// <summary>
        /// The status of the cycle status
        /// </summary>
        public bool CycleStatus => mCycleStatus;

        #endregion

        #region Main Methods

        /// <summary>
        /// Pauses the queue cycle forever into the cycle is resumed. 
        /// If the queue cycle if already paused, nothing will happen
        /// </summary>
        public void PauseQueueCycle()
        {
            // Update the queue cycle status
            mCycleStatus = false;
        }

        /// <summary>
        /// Pauses the queue cycle for certain amount of milliseconds
        /// </summary>
        /// <param name="milliseconds">The amount of milliseconds for the queue cycle to be paused</param>
        public void PauseQueueCycle(int milliseconds)
        {
        }

        /// <summary>
        /// Resumes the queue cycle forever into the cycle is paused again
        /// If the queue cycle is already running, nothing will happen
        /// </summary>
        public void ResumeQueueCycle()
        {
            // Update the queue cycle status
            mCycleStatus = false;
        }

        #endregion
    }
}
