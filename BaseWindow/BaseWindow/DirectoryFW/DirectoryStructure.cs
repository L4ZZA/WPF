using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BaseWindow.DirectoryFW
{
    /// <summary>
    /// A helper class to query info about directories
    /// </summary>
    public static class DirectoryStructure
    {

        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every logical drive on the machine
            return Directory.GetLogicalDrives().Select(drive => 
                new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive })
                    .ToList();
        }

        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Create empty list
            var items = new List<DirectoryItem>();

            #region Get Folders

            // Try and get directories from the folder
            // ignoring any exception
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }

            #endregion

            #region Get Files

            // Try and get files from the folder
            // ignoring any exception
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }

            #endregion

            return items;
        }

        #region Helpers

        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path">Absoulte path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // if no path return empty string
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            var lastSlashIndex = normalizedPath.IndexOf('\\');

            if (lastSlashIndex <= 0)
                return path;

            // Return name after last slash
            return path.Substring(lastSlashIndex + 1);
        }

        #endregion
    }
}