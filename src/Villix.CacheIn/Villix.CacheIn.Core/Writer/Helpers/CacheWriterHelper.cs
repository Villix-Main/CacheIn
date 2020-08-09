using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Villix.CacheIn.Core.Formatters;

namespace Villix.CacheIn.Core.Writer.Helpers
{
    /// <summary>
    /// Methods to help cache writer objects and methods
    /// </summary>
    public static class CacheWriterHelper
    {
        /// <summary>
        /// Gets and return the list of an cache file data
        /// </summary>
        /// <param name="filePath">The file path of the cache file</param>
        /// <returns>The <see cref="List{object}"/> of all the cache data in a cache file</returns>
        public static List<string> GetCacheFileData(string filePath)
        {
            // List to store current cache in cache file
            var currentData = new List<string>();

            // Read and store current cache on cache file
            using (var reader = new StreamReader(filePath))
            {
                // Reads and stores all data and splits it
                var data = reader.ReadToEnd().Split('/');

                // Split all the cache data by using cache line separator '/'
                Parallel.ForEach(data, (d) =>
                {
                    // Check if cache is not empty of just white space
                    if (!string.IsNullOrWhiteSpace(d))
                    {
                        // Add the data to the list
                        currentData.Add(CacheStringFormatter.DefaultFormat(d));
                    }
                });

                reader.Close();
            }

            return currentData;
        }

        /// <summary>
        /// Sets up the cache write process and return default cache file
        /// </summary>
        /// <param name="path">The directory path to store the setup cache files</param>
        public static string SetupWrite(string path)
        {
            // Create cache file directory if theres not one
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Get the appended file directory string
            string filePath = CacheDirectory.AppendFileToDirectory(path, "cache", CacheFileType.txt);

            // If no cache file, create one
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            return filePath;
        }

        
    }
}
