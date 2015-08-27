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
        BasicCalculator calculator;
        Converter converter;
        bool justPressedSign, justPressedEquals;
        string currentBinary, currentOctal, currentDecimal, currentHex;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            statusBar = StatusBar.GetForCurrentView();

            HardwareButtons.BackPressed += QuitApp;

            calculator = new BasicCalculator();
            converter = new Converter();
            justPressedSign = false;
            justPressedEquals = false;
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

            //await statusBar.HideAsync();

            //statusBar.BackgroundColor = (App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush).Color;
            statusBar.BackgroundColor = Windows.UI.Colors.DodgerBlue;
            statusBar.BackgroundOpacity = 1;

            statusBar.ProgressIndicator.Text = "Programmer Calculator";
            statusBar.ProgressIndicator.ProgressValue = 0;

            await statusBar.ProgressIndicator.ShowAsync();
        }

        private void QuitApp(object sender, BackPressedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void digit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (((TextBlock)sender).Text == "0")
                ((TextBlock)sender).Text = "1";
            else
                ((TextBlock)sender).Text = "0";
        }

        private void BinaryOn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if ((bool)((ToggleButton)sender).IsChecked)
            {
                binaryDisplay.Visibility = Visibility.Visible;
                otherAriesDisplay.Visibility = Visibility.Collapsed;

                numberPads.Visibility = Visibility.Collapsed;
                threeDisplays.Visibility = Visibility.Visible;

                showBinaryInput.Begin();
            }
            else
            {
                otherAriesDisplay.Visibility = Visibility.Visible;
                binaryDisplay.Visibility = Visibility.Collapsed;

                numberPads.Visibility = Visibility.Visible;
                threeDisplays.Visibility = Visibility.Collapsed;

                hideBinaryInput.Begin();
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

                if(numberPadDeci.Visibility != Visibility.Visible)
                {
                    showNumberPadDeci.Begin();
                    numberPadDeci.Visibility = Visibility.Visible;
                    numberPadHex.Visibility = Visibility.Collapsed;
                }

                button_2.IsEnabled = true;
                button_3.IsEnabled = true;
                button_4.IsEnabled = true;
                button_5.IsEnabled = true;
                button_6.IsEnabled = true;
                button_7.IsEnabled = true;
                button_8.IsEnabled = true;
                button_9.IsEnabled = true;
                button_dot.IsEnabled = true;
            }
            else if (button.Tag.Equals("octa"))
            {
                Deci.IsChecked = false;
                Octa.IsChecked = true;
                Hexa.IsChecked = false;
                Bina.IsChecked = false;

                if (numberPadDeci.Visibility != Visibility.Visible)
                {
                    showNumberPadDeci.Begin();
                    numberPadDeci.Visibility = Visibility.Visible;
                    numberPadHex.Visibility = Visibility.Collapsed;
                }

                button_2.IsEnabled = true;
                button_3.IsEnabled = true;
                button_4.IsEnabled = true;
                button_5.IsEnabled = true;
                button_6.IsEnabled = true;
                button_7.IsEnabled = true;
                button_8.IsEnabled = false;
                button_9.IsEnabled = false;
                button_dot.IsEnabled = false;
            }
            else if (button.Tag.Equals("hexa"))
            {
                Deci.IsChecked = false;
                Octa.IsChecked = false;
                Hexa.IsChecked = true;
                Bina.IsChecked = false;

                if (numberPadHex.Visibility != Visibility.Visible)
                {
                    hideNumberPadDeci.Begin();
                    numberPadDeci.Visibility = Visibility.Collapsed;
                    numberPadHex.Visibility = Visibility.Visible;
                }
            }
            else if (button.Tag.Equals("bina"))
            {
                Deci.IsChecked = false;
                Octa.IsChecked = false;
                Hexa.IsChecked = false;
                Bina.IsChecked = true;

                if (numberPadDeci.Visibility != Visibility.Visible)
                {
                    showNumberPadDeci.Begin();
                    numberPadDeci.Visibility = Visibility.Visible;
                    numberPadHex.Visibility = Visibility.Collapsed;
                }

                button_2.IsEnabled = false;
                button_3.IsEnabled = false;
                button_4.IsEnabled = false;
                button_5.IsEnabled = false;
                button_6.IsEnabled = false;
                button_7.IsEnabled = false;
                button_8.IsEnabled = false;
                button_9.IsEnabled = false;
                button_dot.IsEnabled = false;
            }
        }

        private void twoComClicked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var key = (sender as Button).Content.ToString();
            string processText;

            switch (key)
            {
                #region fourOperations
                case "+":
                    justPressedEquals = false;
                    if (justPressedSign)
                    {
                        displayResultTextBlock.Text = key;
                        calculator.LastSign = BasicCalculator.sign.plus;
                    }
                    else
                    {
                        displayResultTextBlock.Text = calculator.Add(out processText);
                        displayProcessTextBlock.Text = processText;
                    }
                    justPressedSign = true;
                    break;
                case "-":
                    justPressedEquals = false;
                    if (justPressedSign)
                    {
                        displayResultTextBlock.Text = key;
                        calculator.LastSign = BasicCalculator.sign.minus;
                    }
                    else
                    {
                        displayResultTextBlock.Text = calculator.Sub(out processText);
                        displayProcessTextBlock.Text = processText;
                    }
                    justPressedSign = true;
                    break;
                case "×":
                    justPressedEquals = false;
                    if (justPressedSign)
                    {
                        displayResultTextBlock.Text = key;
                        calculator.LastSign = BasicCalculator.sign.multi;
                    }
                    else
                    {
                        displayResultTextBlock.Text = calculator.Multi(out processText);
                        displayProcessTextBlock.Text = processText;
                    }
                    justPressedSign = true;
                    break;
                case "÷":
                    justPressedEquals = false;
                    if (justPressedSign)
                    {
                        displayResultTextBlock.Text = key;
                        calculator.LastSign = BasicCalculator.sign.div;
                    }
                    else
                    {
                        displayResultTextBlock.Text = calculator.Div(out processText);
                        displayProcessTextBlock.Text = processText;
                    }
                    justPressedSign = true;
                    break;
                #endregion

                case ".":
                    justPressedSign = false;
                    justPressedEquals = false;
                    if (displayResultTextBlock.Text.Contains(".") || displayResultTextBlock.Text.Contains("+") || displayResultTextBlock.Text.Contains("-") 
                        || displayResultTextBlock.Text.Contains("×") || displayResultTextBlock.Text.Contains("÷"))
                    {
                        // do nothing
                    }
                    else
                    {
                        displayResultTextBlock.Text += ".";
                    }
                    break;
                case "DEL":
                    justPressedSign = false;
                    justPressedEquals = false;
                    if (displayResultTextBlock.Text.Equals("+") || displayResultTextBlock.Text.Equals("-")
                        || displayResultTextBlock.Text.Equals("×") || displayResultTextBlock.Text.Equals("÷"))
                    {
                        // do nothing
                    }
                    else if(displayResultTextBlock.Text.Length < 2)
                    {
                        displayResultTextBlock.Text = "0";
                    }
                    else
                    {
                        displayResultTextBlock.Text = displayResultTextBlock.Text.Substring(0, displayResultTextBlock.Text.Length - 1);
                    }
                    break;
                case "=":
                    justPressedSign = false;
                    justPressedEquals = true;
                    processText = calculator.Equals();
                    displayProcessTextBlock.Text = processText;
                    displayResultTextBlock.Text = processText;
                    break;
                case "C":
                    justPressedSign = false;
                    justPressedEquals = false;
                    displayProcessTextBlock.Text = "=";
                    displayResultTextBlock.Text = "0";
                    calculator.Initialise();
                    break;
                default:
                    if (justPressedEquals || displayResultTextBlock.Text.Equals("0") || displayResultTextBlock.Text.Equals("+") || displayResultTextBlock.Text.Equals("-") ||
                        displayResultTextBlock.Text.Equals("×") || displayResultTextBlock.Text.Equals("÷"))
                    {
                        displayResultTextBlock.Text = key;
                        calculator.UpdateCurrent(key);
                    }
                    else
                    {
                        displayResultTextBlock.Text += key;
                        calculator.UpdateCurrent(displayResultTextBlock.Text);
                    }

                    justPressedSign = false;
                    justPressedEquals = false;
                    break;
            }
        }

        private void Button_Click_Hex(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Panels()
        {

        }
    }
}
