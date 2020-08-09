using System;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// Properties and methods to define a base of a cache item
    /// </summary>
    public interface IBaseCache
    {
        /// <summary>
        /// The name of the cache item
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The type of the cache item
        /// </summary>
        Type Type { get; set; }

        /// <summary>
        /// The type of cache to store in cache file
        /// </summary>
        CacheType CacheType { get; }

    }
}