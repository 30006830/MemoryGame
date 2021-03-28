using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemoryGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            Window.Current.SetTitleBar(AppTitleBar);

            ApplicationView view = ApplicationView.GetForCurrentView();
            ApplicationViewTitleBar titleBar = view.TitleBar;
            titleBar.ForegroundColor = Windows.UI.Color.FromArgb(255, 0, 0, 255);
            titleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(0, 0, 0, 0);
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Color.FromArgb(20, 255, 255, 255);
            titleBar.ButtonPressedBackgroundColor = Windows.UI.Color.FromArgb(50, 255, 255, 255);
            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Color.FromArgb(0, 255, 255, 255);

            Container.Navigate(typeof(Home));               
        }

        #region Navigation

        private void HowToPlayClick(object sender, TappedRoutedEventArgs e)
        {
            Container.Navigate(typeof(Home));
        }

        private void MemoryGameClick(object sender, TappedRoutedEventArgs e)
        {
            Container.Navigate(typeof(MemoryGame));
        }

        #endregion
    }
}
