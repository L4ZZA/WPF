using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BaseWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Contructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region On Loaded

        /// <summary>
        /// When the application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem {
                    Header = drive
                };

                // Add Dummy item to show expand arrow
                item.Items.Add(null);

                // Add it to the main preview
                FolderView.Items.Add(item);
            }
        }

        #endregion
    }
}
