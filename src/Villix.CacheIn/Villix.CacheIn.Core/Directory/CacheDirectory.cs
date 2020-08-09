using System;
using System.IO;

namespace Villix.CacheIn.Core
{
    /// <summary>
    /// Methods used to check and manipulate cache file directory's
    /// </summary>
    public static class CacheDirectory
    {
        /// <summary>
        /// Creates the cache file directory
        /// </summary>
        public static string CreateDefaultDirect()
        {
            // The directory path
            string directoryPath = @"C:\temp\Data\Cache";

            // The number to add to the end of 'Data'
            int copyNumber = 0;

            // If current directory path exists, add one to end of word 'Data'
            while (Directory.Exists(directoryPath))
                directoryPath = $@"C:\temp\Data\Cache{ ++copyNumber }";

            // Create the cache file directory in current machine
            Directory.CreateDirectory(directoryPath);

            return directoryPath;
        }

        /// <summary>
        /// Appends a file string to the end of a directory path
        /// </summary>
        /// <param name="path">The directory path to get the file string</param>
        /// <param name="fileName">The name of the file to addend to directory</param>
        /// <param name="fileType">The type of file to append to directory</param>
        /// <returns>The appended file extension to passed in <see cref="string"/></returns>
        public static string AppendFileToDirectory(string path, string fileName, CacheFileType fileType)
        {
            // Replace any '\' in path with '/' for betting cache reading and writing
            string directoryPath = path.Replace(@"\", @"/");

            // Append new file string to directory path
            directoryPath += $"/{ fileName }.{ fileType }";
           
            // Return the directory path with all '/' replace with '\'
            return directoryPath.Replace(@"/", @"\");
        }

    }
}
