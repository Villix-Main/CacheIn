using System;
using System.Threading.Tasks;
using Villix.CacheIn.Core.Exceptions;

namespace Villix.CacheIn.Core.Queue.Helpers
{
    /// <summary>
    /// Methods the manipulate an queue collection 
    /// </summary>
    public static class QueueCollectionHelpers
    {
        /// <summary>
        /// Attempts to find and return the name of an cache item
        /// </summary>
        /// <param name="item">The item to look for name in</param>
        public async static Task<string> GetCacheItemNameAsync(string item)
        {
            // To store the cache item name
            string name = "";

            await Task.Run(() =>
            {
                foreach (char c in item)
                {
                    // If character is a cache beginner char continue to loop 
                    if (c == '/' || c == '*')
                        continue;
                    // Break from loop if character is a end name char
                    else if (c == ':')
                        break;

                    // Add the character to the name
                    name += c;
                }
            });

            return name;
        }

        #region Item Checker Methods

        /// <summary>
        /// Checks if an item is a valid queue item and if the queue is currently available for new items
        /// </summary>
        /// <param name="item">The new item to check</param>
        /// <param name="cycle">The queue cycle</param>
        /// <param name="length">The length of the current queue collection</param>
        /// <param name="capacity">The capacity of the queue collection</param>
        public static void CheckItem<TQueueType>(TQueueType item, QueueCycle cycle, int length, int capacity)
        {
            // Check if the item in null
            if (item == null)
                throw new ArgumentNullException("Item cannot be null");

            // Check if queue cycle is paused
            if (!cycle.CycleStatus)
                throw new AddDuringPausedQueueException();

            // If queue collection over capacity throw exception
            if (length > capacity)
                throw new QueueCollectionOverCapacityException();
        }

        #endregion
    }
}
