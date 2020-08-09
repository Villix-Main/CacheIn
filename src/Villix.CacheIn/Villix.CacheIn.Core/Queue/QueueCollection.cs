using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Villix.CacheIn.Core.Queue.Helpers;

namespace Villix.CacheIn.Core.Queue
{
    /// <summary>
    /// A queue collection to be used to store cache data before writing it to files
    /// </summary>
    public class QueueCollection //: IQueueCollection<TQueueType>
    {
        #region Private Members

        /// <summary>
        /// Queue Collection where all items in string cache format to be stored
        /// </summary>
        private List<string> mCollection = new List<string>();

        /// <summary>
        /// The capacity of the queue collection
        /// </summary>
        private int mQueueCapacity;

        /// <summary>
        /// The queue cycle for this current instance
        /// </summary>
        private QueueCycle mCycle = new QueueCycle();

        #endregion

        #region Public Properties

        /// <summary>
        /// The length of the queue collection 
        /// </summary>
        public int Length => mCollection.Count;

        /// <summary>
        /// The capacity of the queue collection
        /// </summary>
        public int QueueCapicity => mQueueCapacity;

        /// <summary>
        /// The queue cycle for this current instance
        /// </summary>
        public QueueCycle Cycle => mCycle;

        #endregion

        #region Main Methods

        #region Add To Queue Methods

        /// <summary>
        /// Adds a named item to the current queue collection
        /// </summary>
        /// <param name="value">The item to add</param>
        /// <param name="name">The name of the item</param>
        public void AddItemToCacheQueue<TItemType>(TItemType value, string name)
        {
            // Check if the item is valid
            QueueCollectionHelpers.CheckItem(value, mCycle, Length, mQueueCapacity);

            // Add item and it's name to queue collection
            mCollection.Add($"/{ name }:{ value }@{ value.GetType().Name }");
        }
        

        /// <summary>
        /// Adds a named object to the current queue collection
        /// </summary>
        /// <param name="obj">The object to add</param>
        /// <param name="name">The name of the object</param>
        public void AddObjectToCacheQueue<TObjType>(TObjType obj, string name)
            where TObjType : class
        {
            // Check if object is valid
            QueueCollectionHelpers.CheckItem(obj, mCycle, Length, mQueueCapacity);
            
            // Start cache string 
            string cacheObject = $"/*{ name }:";

            Parallel.ForEach(typeof(TObjType).GetProperties(), (property) =>
            {
                // Add all property names and it's values to cached object
                cacheObject += $"{ property.Name }={ property.GetValue(obj) },";
            });

            // Write object class type
            cacheObject += $"@{ obj.GetType().Name }";
            
            // Add object to queue collection
            mCollection.Add(cacheObject);
        }

        public void AddCollectionToCacheQueue<TQueueCollectionType>(IEnumerable<TQueueCollectionType> collection, string name)
        {
            // Check if collection is valid
            QueueCollectionHelpers.CheckItem(collection, mCycle, Length, mQueueCapacity);

            // Start cache string
            string cacheCollection = $"/${ name }";

            Parallel.ForEach(collection, (data) =>
            {
                // Add all items in collection to cached collection
                cacheCollection += $"{ data },";
            });

            // Write collection item type
            cacheCollection += $"@{ typeof(TQueueCollectionType).Name }";

            // Add collection to queue collection
            mCollection.Add(cacheCollection);
        }


        #endregion

        #region Remove Item from Queue Methods

        /// <summary>
        /// Removes the first or all of an item from the queue collection
        /// </summary>
        /// <param name="name">The name of the item</param>
        /// <param name="removeAll">True if to remove all instances of an item, and false if only the first</param>
        public async Task<bool> RemoveItemFromCacheQueue(string name, bool removeAll)
        {
            foreach (string cache in mCollection)
            {
                string cacheName = "";

                cacheName = await QueueCollectionHelpers.GetCacheItemNameAsync(cache);

                if (name == cacheName)
                {
                    // If dev wants to remove all instances of name
                    if (removeAll)
                        mCollection.RemoveAll(c => c == cache);
                    else
                        // Otherwise remove first instance of name
                        mCollection.Remove(cache);

                    return true;
                }
            }

            // If no instance of name in collection return false
            return false;
        }

        #endregion

        /// <summary>
        /// Returns back the current class instance queue collection 
        /// </summary>
        /// <returns>The current queue collection List</returns>
        public List<string> GetCollection() => mCollection;

        /// <summary>
        /// Clears the queue collection
        /// </summary>
        public void ClearCacheQueue() => mCollection.Clear();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QueueCollection()
        {
            // Set queue collection capacity to highest value
            mQueueCapacity = 10000;
        }

        /// <summary>
        /// Constructor to take in the queue collection capacity
        /// </summary>
        /// <param name="capicity">The capacity of the queue collection</param>
        public QueueCollection(int capicity)
        {
            // Set queue collection capacity
            mQueueCapacity = capicity;
        }

        #endregion

        #region Get Queue Item Methods

        public List<string> GetQueueItems()
        {
            // List to store all items in current queue
            var items = new List<string>();

            // Get and store all named items in queue collection
            Parallel.ForEach(mCollection, (cache) => items.Add(cache));

            return items;
        }

        #endregion
    }
}
