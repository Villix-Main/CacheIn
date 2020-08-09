using System.Collections;
using System.Collections.Generic;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// An cache collection to be stored in the cache file
    /// </summary>
    /// <typeparam name="TCollectionType">The </typeparam>
    public class CacheCollection<TCollectionType> : BaseCache, IEnumerable<TCollectionType>
    {

        #region Collection Enumeration

        public IEnumerator<TCollectionType> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
