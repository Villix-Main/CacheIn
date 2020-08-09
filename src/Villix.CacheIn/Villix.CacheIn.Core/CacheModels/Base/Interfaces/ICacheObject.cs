using System.Collections.Generic;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// Methods to define a semi-base of a cache object
    /// </summary>
    public interface ICacheObject : IBaseCache
    {
        /// <summary>
        /// Gets and returns all the properties value in the object
        /// </summary>
        /// <returns>A <see cref="List{object}"/> of the values of the object properties</returns>
        List<object> GetPropertiesValue();
    }
}
