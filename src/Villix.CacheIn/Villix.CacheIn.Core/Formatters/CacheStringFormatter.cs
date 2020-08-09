namespace Villix.CacheIn.Core.Formatters
{
    // Set of methods to format cache string data
    public static class CacheStringFormatter
    {
        /// <summary>
        /// Does a default format on a <see cref="string"/>
        /// </summary>
        /// <param name="cacheString">The cache string to format</param>
        /// <returns>The formatted passed in cache string</returns>
        public static string DefaultFormat(string cacheString)
        {
            // To store the formatted cache string
            string formatCache = "";

            // Add cache line separator to current
            formatCache += '/';

            foreach (char c in cacheString)
            {
                // Check if char is not a new line operator
                if (c != '\r' && c != '\n')
                    formatCache += c;
                else
                    break;
            }

            return formatCache;
        }
    }
}
