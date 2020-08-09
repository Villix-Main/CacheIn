using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Villix.CacheIn.Core.Writer.Helpers;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// An overloaded class of cache writer for shorthand write methods
    /// </summary>
    public class CacheWriter
    {
        #region Public Properties

        /// <summary>
        /// The directory path to be used for shorthand cache write methods. Default to default path
        /// </summary>
        public static string DirectoryPath { get; set; } = @"C:\temp\data\";

        #endregion

        #region Main Methods

        /// <summary>
        /// Shorthand method to write an item to a specific directory
        /// </summary>
        /// <param name="value">The item to write to cache file</param>
        /// <param name="name">The name of the item</param>
        /// <param name="overrideCurrent">If new item should override the current cache in cache file</param>
        /// <param name="path">The directory to write the cache at. if not supplied, directoryPath will be used</param>
        /// <typeparam name="Ttype">The type of data to be stored in cache file</typeparam>
        public static async Task WriteItemAsync<Ttype>(Ttype value, string name, bool overrideCurrent, string path = null)
        {
            // If path is empty of white space, use DirectoryPath as path
            if (string.IsNullOrWhiteSpace(path))
                path = DirectoryPath;

            // Get file path
            string filePath = CacheWriterHelper.SetupWrite(path);

            // Check if dev wants to override current cache in cache file
            if (overrideCurrent)
            {
                var item = new CacheItem(name, typeof(Ttype));

                using (var writer = new StreamWriter(filePath))
                    // Write item to cache file, while overriding current cache
                    await writer.WriteLineAsync($"{ name }:{ value }@{ value.GetType().Name }");

                return;
            }

            // Get the current cache data in cache file using filePath
            List<string> currentCache = CacheWriterHelper.GetCacheFileData(filePath);

            using (var writer = new StreamWriter(filePath))
            {
                if (currentCache != null)
                    // Write old cache data to cache file
                    //Parallel.ForEach(currentCache, async (c) => await writer.WriteLineAsync(c));
                    foreach (string c in currentCache)
                        await writer.WriteLineAsync(c);
                
                
                // Write the cache item to cache file
                await writer.WriteLineAsync($"/{ name }:{ value }@{ value.GetType().Name }");
               
                writer.Close();
            }
        }

        /// <summary>
        /// Shorthand method to write an object to a specific directory
        /// </summary>
        /// <param name="obj">The object to write to cache file</param>
        /// <param name="name">The name of the object</param>
        /// <param name="overrideCurrent">If new object should override the current cache in cache file</param>
        /// <param name="path">The directory to write the cache at</param>
        /// <typeparam name="TObjectType">The type of class to be written to cache file</typeparam>
        public static async Task WriteObjectAsync<TObjectType>(TObjectType obj, string name, bool overrideCurrent, string path = null)
            where TObjectType : class
        {
            // If path is empty of white space, use DirectoryPath as path
            if (string.IsNullOrWhiteSpace(path))
                path = DirectoryPath;

            // Get cache file path
            string filePath = CacheWriterHelper.SetupWrite(path);

            // Check if dev wants to override cache in cache file
            if (overrideCurrent)
            {
                using (var writer = new StreamWriter(filePath))
                {
                    // Write cache item start title
                    await writer.WriteAsync($"/*{ name }:");

                    Parallel.ForEach(typeof(TObjectType).GetProperties(), (property) =>
                    {
                        // Write main object info in cache file using default object format 
                        writer.Write($"{ property.Name }={ property.GetValue(obj) },");
                    });

                    // Write object class type
                    await writer.WriteAsync($"@{ obj.GetType().Name }");
                }

                return;
            }

            // Get the current cache data in cache file using filePath
            var currentCache = CacheWriterHelper.GetCacheFileData(filePath);

            using (var writer = new StreamWriter(filePath))
            {
                // Write old cache data to cache file
                foreach (string c in currentCache)
                    await writer.WriteLineAsync(c);

                // Write cache item start title
                await writer.WriteAsync($"/*{ name }:");

                Parallel.ForEach(typeof(TObjectType).GetProperties(), (property) =>
                {
                    // Write main object info in cache file using default object format 
                    writer.Write($"{ property.Name }={ property.GetValue(obj) },");
                });

                // Write object class type
                await writer.WriteAsync($"@{ obj.GetType().Name }");
            }
        }

        #endregion
    }
}
