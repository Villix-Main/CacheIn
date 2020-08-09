using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Villix.CacheIn.Core.Queue;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// Default management for writing and reading cache files
    /// </summary>
    public class CacheManager : IDisposable
    {
        #region Private Members

        /// <summary>
        /// The directory path to store cache file.
        /// </summary>
        private string mDirectoryPath;

        /// <summary>
        /// The format to write the cache files
        /// </summary>
        private CacheFormat mCacheFormat;

        /// <summary>
        /// The collection to store all the queued cache files
        /// </summary>
        private QueueCollection mQueueCollection = new QueueCollection();

        #endregion

        #region Public Properties

        /// <summary>
        /// The directory path to store cache files
        /// </summary>
        public string DirectoryPath => mDirectoryPath;

        /// <summary>
        /// The format to write the cache files
        /// </summary>
        public CacheFormat CacheFormat => mCacheFormat;

        /// <summary>
        /// The collection to store all the queued cache files
        /// </summary>
        public QueueCollection Queue => mQueueCollection;

        #endregion

        #region Cache Writer Methods

        public void BeginWrite(CancellationToken cancellationToken)
        {
        }


        #endregion

        #region Cache Reader Methods



        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CacheManager()
        {
            // Create the cache file directory
            mDirectoryPath = CacheDirectory.CreateDefaultDirect();

            // Set default cache format 
            mCacheFormat = CacheFormat.OneFile;
        }

        /// <summary>
        /// Constructor to take in preferred directory path
        /// </summary>
        /// <param name="path">The directory path to store cache files</param>
        public CacheManager(string path)
        {
            // Set preferred directory path
            mDirectoryPath = path;

            // Set default cache format 
            mCacheFormat = CacheFormat.OneFile;
        }

        public CacheManager(CacheFormat cacheFormat)
        {
            // Create the cache file directory
            mDirectoryPath = CacheDirectory.CreateDefaultDirect();

            // Set preferred cache format
            mCacheFormat = cacheFormat;
        }

        /// <summary>
        /// Constructor to take in preferred directory path and preferred cache format
        /// </summary>
        /// <param name="path">The directory to store cache files</param>
        /// <param name="cacheFormat">The format to store and write cache files</param>
        public CacheManager(string path, CacheFormat cacheFormat)
        {
            // Set preferred directory path
            mDirectoryPath = path;

            // Set preferred cache format
            mCacheFormat = cacheFormat;
        }

        public CacheManager(string path, CacheFormat cacheFormat, int queueCapacity)
        {
            // Set preferred directory path
            mDirectoryPath = path;

            // Set preferred cache format
            mCacheFormat = cacheFormat;

            mQueueCollection = new QueueCollection(queueCapacity);
        }

        #endregion

        #region Disposal

        public void Dispose()
        {
            mQueueCollection = null;
        }

        #endregion
    }
}