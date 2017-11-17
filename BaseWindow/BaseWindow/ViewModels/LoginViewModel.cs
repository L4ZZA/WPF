using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BaseWindow.ViewModels
{
    /// <summary>
    /// The View Model for login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member



        #endregion

        #region Public Properties

        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the user password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await Task.Delay(500);
        }
    }
}