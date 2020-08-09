using System.Collections.Generic;
using Villix.CacheIn.Core.Queue;
using Villix.CacheIn.Core.Writer.Helpers;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// The writer to write cache to cache files
    /// </summary>
    /// <typeparam name="Ttype">The type of queue item to be written to cache files</typeparam>
    public class CacheWriter<Ttype> : IWriter
    {
        #region Private Members

        /// <summary>
        /// The path where the cache and cache file and log where be stored
        /// </summary>
        private string mDirectoryPath;

        /// <summary>
        /// The queue collection to have items written to cache files
        /// </summary>
        private QueueCollection mQueue;
       
        /// <summary>
        /// The format of writing cache to cache files
        /// </summary>
        private CacheFormat mCacheFormat;

        #endregion

        #region Public Properties

        /// <summary>
        /// The path where the cache and cache file and log where be stored
        /// </summary>
        public string DirectoryPath
        {
            get
            {
                // If mPath is null return the default file path 
                if (string.IsNullOrWhiteSpace(mDirectoryPath))
                    return @"C:\temp\data\";
                else

                    // Otherwise set return mPath
                    return mDirectoryPath;
            }

            set
            {
                mDirectoryPath = value;
            }
        }

        #endregion

        #region Main Methods

        public void WriteQueueToFile(QueueCollection queue, bool overrideCurrent)
        {
            // Get file path
            string filePath = CacheWriterHelper.SetupWrite(DirectoryPath);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="path">The path where the cache file will be stored, can be change at anytime</param>
        /// <param name="queue">The queue collection to be written to be cache files</param>
        /// <param name="cacheFormat">The format to write the cache in</param>
        public CacheWriter(string path, QueueCollection queue, CacheFormat cacheFormat)
        {
            // Set queue collection
            mQueue = queue;

            // Set the cache format
            mCacheFormat = cacheFormat;
        }

        #endregion
    }
}

