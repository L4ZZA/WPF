using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BaseWindow.Expressions;
using PropertyChanged;

namespace BaseWindow
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// A base view model that fires Property Changed events as needed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Runs a command if the udating flag is not set.
        /// If the flag is true (indicating the function is already running) the action is not run.
        /// If the flag is false (indicating no running function) then the action is ru.
        /// Once the action is finished if it was run, then the flag is reset to false.
        /// </summary>
        /// <param name="updatingFlag">The boolean flag defining if the command is already running</param>
        /// <param name="action">The action to run if it not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // check if the flag property is true (meaning the function is already running)
            if (updatingFlag.GetPropertyValue())
                return;

            // Set the property flag to true to indicate we're runnig
            updatingFlag.SetPropertyValue(true);

            try
            {
                // Run the passed action
                await action();
            }
            finally
            {
                // Set the property flag back to false now it's finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}