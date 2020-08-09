using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// An cache object to be stored in the cache file
    /// </summary>
    public class CacheObject : BaseCache, ICacheObject
    {
        #region Private Members

        /// <summary>
        /// The object to get properties from and store in cache file
        /// </summary>
        private object mObject;

        /// <summary>
        /// The collection of the properties of an object
        /// </summary>
        private List<PropertyInfo> mProperties;

        #endregion

        #region Public Methods

        public List<object> GetPropertiesValue()
        {
            // To store the properties value
            var propValues = new List<object>();

            // Get all values and store them
            Parallel.ForEach(mProperties, (property) =>
            {
                propValues.Add(property.GetValue(mObject));
            });

            return propValues;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to take in information about an object
        /// </summary>
        /// <param name="obj">The obj to cache</param>
        /// <param name="name">The name of the object to cache</param>
        public CacheObject(object obj, string name)
        {
            // Set cache item information
            Name = name;
            Type = obj.GetType();
            mProperties = new List<PropertyInfo>();
            mObject = obj;
            
            // Get and store all object property in property list
            Parallel.ForEach(Type.GetProperties(), (property) =>
            {
                // Store property
                mProperties.Add(property);
            });
        }

        #endregion
    }
}
