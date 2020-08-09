namespace Villix.CacheIn.Core
{
    /// <summary>
    /// The way of storing and writing data to cache file
    /// </summary>
    public enum CacheFormat
    {
        /// <summary>
        /// Writes all queue cache into one file (recommended)
        /// </summary>
        OneFile = 0,

        /// <summary>
        /// Writes all queue cache into separate files
        /// </summary>
        SeparateFiles = 1

    }
}
