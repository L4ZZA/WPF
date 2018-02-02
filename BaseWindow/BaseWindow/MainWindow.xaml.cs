using System.Windows;
using BaseWindow.ViewModels;

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

            DataContext = new WindowViewModel(this);
        }

        #endregion
    }
}
