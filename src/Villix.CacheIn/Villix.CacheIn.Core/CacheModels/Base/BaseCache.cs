using System;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// A base for all cache items types in CacheIn
    /// </summary>
    public class BaseCache : IBaseCache
    {
        #region Private Members

        /// <summary>
        /// The name of the cache item
        /// </summary>
        private string mName;

        /// <summary>
        /// The type of the cache item
        /// </summary>
        private Type mType;

        #endregion

        #region Public Properties
        
        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public Type Type
        {
            get
            {
                return mType;
            }

            set
            {
                mType = value;
            }
        }

        public CacheType CacheType { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to set default cache item information
        /// </summary>
        public BaseCache()
        {
            // Set default cache information
            mName = string.Empty;
            mType = null;
        }

        /// <summary>
        /// Default Constructor, to take in information about cache item
        /// </summary>
        /// <param name="name">The name of the cache item</param>
        /// <param name="type">The type of the cache item</param>
        public BaseCache(string name, Type type)
        {
            // Set cache item information
            mName = name;
            mType = type;
        }

        #endregion
    }
}
