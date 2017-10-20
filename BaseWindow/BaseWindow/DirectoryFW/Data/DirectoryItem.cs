using BaseWindow.DirectoryFW;

namespace BaseWindow
{
    /// <summary>
    /// Info about a directory item (drive, file or folder)
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name
        {
            get { return Type == DirectoryItemType.Drive ? 
                    FullPath : DirectoryStructure.GetFileFolderName(FullPath); }
        }
    }
}