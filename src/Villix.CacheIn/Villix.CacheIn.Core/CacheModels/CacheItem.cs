using System;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// An default cache item to be stored in a cache file
    /// </summary>
    public class CacheItem : BaseCache
    {
        #region Constructor

        /// <summary>
        /// Default Constructor to take in args for cache item information
        /// </summary>
        /// <param name="name">The name of the cache</param>
        /// <param name="type">The type of cache item</param>
        public CacheItem(string name, Type type) : base(name, type)
        {
        }

        /// <summary>
        /// Constructor to take in information of an c# variable
        /// </summary>
        /// <param name="item">The item to cache</param>
        /// <param name="name">The name of the item to cache</param>
        public CacheItem(object item, string name) 
        {
            // Set cache item information
            Name = name;
            Type = item.GetType();
        }

        #endregion
    }
}
