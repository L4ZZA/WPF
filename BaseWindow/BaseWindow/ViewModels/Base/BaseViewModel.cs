using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    }
}