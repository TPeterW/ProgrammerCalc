using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Programmer_Calc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StatusBar statusBar;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            statusBar = StatusBar.GetForCurrentView();

            HardwareButtons.BackPressed += QuitApp;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            await statusBar.HideAsync();
        }

        private void digit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (((TextBlock)sender).Text == "0")
                ((TextBlock)sender).Text = "1";
            else
                ((TextBlock)sender).Text = "0";
        }

        private void QuitApp(object sender, BackPressedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void twoComClicked(object sender, RoutedEventArgs e)
        {
            
        }

        private void BinaryOn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if ((bool)((ToggleButton)sender).IsChecked)
            {
                BinaryDisplay.Visibility = Windows.UI.Xaml.Visibility.Visible;
                otherAriesDisplay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                
            }
            else
            {
                otherAriesDisplay.Visibility = Windows.UI.Xaml.Visibility.Visible;
                BinaryDisplay.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void arieTapped(object sender, TappedRoutedEventArgs e)
        {
            var button = sender as ToggleButton;

            if(button.Tag.Equals("deci"))
            {
                    Deci.IsChecked = true;
                    Octa.IsChecked = false;
                    Hexa.IsChecked = false;
                    Bina.IsChecked = false;
            }
            else if (button.Tag.Equals("octa"))
            {
                    Deci.IsChecked = false;
                    Octa.IsChecked = true;
                    Hexa.IsChecked = false;
                    Bina.IsChecked = false;
            }
            else if (button.Tag.Equals("hexa"))
            {
                    Deci.IsChecked = false;
                    Octa.IsChecked = false;
                    Hexa.IsChecked = true;
                    Bina.IsChecked = false;
            }
            else if (button.Tag.Equals("bina"))
            {
                    Deci.IsChecked = false;
                    Octa.IsChecked = false;
                    Hexa.IsChecked = false;
                    Bina.IsChecked = true;
            }
        }
    }
}
