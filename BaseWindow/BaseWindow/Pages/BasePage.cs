using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BaseWindow
{
    /// <summary>
    /// A base page for all pages to gain base functionalities
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Private Fields

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion 

        #region Public Properties

        /// <summary>
        /// The animation that plays when the page is first Loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeFromRight;

        /// <summary>
        /// The animation that plays when the page is first Unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// Time the slide anymation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                // If nothing has changed don't do anything
                if (mViewModel == value)
                    return;

                // update the value
                mViewModel = value;

                // Update the current data context
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // If we are animating in, hide to begin with
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            Loaded += BasePage_LoadedAsync;

            this.ViewModel = new VM();
        }

        #endregion

        #region Animation Load/Unload

        /// <summary>
        /// Perform any required animation once the page is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        /// <summary>
        /// Animates the page In
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeFromRight:

                    // Start animation
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start animation
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}