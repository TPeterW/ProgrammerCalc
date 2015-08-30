using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Notifications;
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
        string currentBinary;
        int currentArie;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            statusBar = StatusBar.GetForCurrentView();

            HardwareButtons.BackPressed += Quit_App;

            calculator = new BasicCalculator();
            converter = new Converter();
            justPressedSign = false;
            justPressedEquals = false;
            currentArie = 10;

            decimalDisplay.Text = "0";
            octalDisplay.Text = "0";
            hexDisplay.Text = "0";

            #region initialise currentBinary
            currentBinary = "";
            for(int i = 0; i < 64; i++)
            {
                currentBinary += "0";
            }
            #endregion
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

        private void Quit_App(object sender, BackPressedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void Digit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //string tempResult = "";         // prepare to make a new string to put back into the panel

            if (((TextBlock)sender).Text == "0")
                ((TextBlock)sender).Text = "1";
            else
                ((TextBlock)sender).Text = "0";

            #region updateCurrentBinary
            currentBinary = "";

            currentBinary += dig63.Text;
            currentBinary += dig62.Text;
            currentBinary += dig61.Text;
            currentBinary += dig60.Text;
            currentBinary += dig59.Text;
            currentBinary += dig58.Text;
            currentBinary += dig57.Text;
            currentBinary += dig56.Text;

            currentBinary += dig55.Text;
            currentBinary += dig54.Text;
            currentBinary += dig53.Text;
            currentBinary += dig52.Text;
            currentBinary += dig51.Text;
            currentBinary += dig50.Text;
            currentBinary += dig49.Text;
            currentBinary += dig48.Text;

            currentBinary += dig47.Text;
            currentBinary += dig46.Text;
            currentBinary += dig45.Text;
            currentBinary += dig44.Text;
            currentBinary += dig43.Text;
            currentBinary += dig42.Text;
            currentBinary += dig41.Text;
            currentBinary += dig40.Text;

            currentBinary += dig39.Text;
            currentBinary += dig38.Text;
            currentBinary += dig37.Text;
            currentBinary += dig36.Text;
            currentBinary += dig35.Text;
            currentBinary += dig34.Text;
            currentBinary += dig33.Text;
            currentBinary += dig32.Text;

            currentBinary += dig31.Text;
            currentBinary += dig30.Text;
            currentBinary += dig29.Text;
            currentBinary += dig28.Text;
            currentBinary += dig27.Text;
            currentBinary += dig26.Text;
            currentBinary += dig25.Text;
            currentBinary += dig24.Text;

            currentBinary += dig23.Text;
            currentBinary += dig22.Text;
            currentBinary += dig21.Text;
            currentBinary += dig20.Text;
            currentBinary += dig19.Text;
            currentBinary += dig18.Text;
            currentBinary += dig17.Text;
            currentBinary += dig16.Text;

            currentBinary += dig15.Text;
            currentBinary += dig14.Text;
            currentBinary += dig13.Text;
            currentBinary += dig12.Text;
            currentBinary += dig11.Text;
            currentBinary += dig10.Text;
            currentBinary += dig09.Text;
            currentBinary += dig08.Text;

            currentBinary += dig07.Text;
            currentBinary += dig06.Text;
            currentBinary += dig05.Text;
            currentBinary += dig04.Text;
            currentBinary += dig03.Text;
            currentBinary += dig02.Text;
            currentBinary += dig01.Text;
            currentBinary += dig00.Text;
            #endregion

            #region uselessPoorCode
            //int position = 0;
            //bool canParse = int.TryParse(((TextBlock)sender).Name.Substring(3, 2), out position);

            //for (int i = 0; i < 64; i++)
            //{
            //    if ((63 - i) == position)
            //    {
            //        tempResult += ((TextBlock)sender).Text;
            //    }
            //    else
            //    {
            //        tempResult += currentBinary[i];
            //    }
            //}

            //currentDecimal = converter.binaToDeci(tempResult);
            ////decimalDisplay.Text = position + "";
            //Update_Panels(currentDecimal);
            //calculator.UpdateCurrent(currentDecimal);
            //if (currentArie == 2)
            //{
            //    displayResultTextBlock.Text = converter.binaToDeci(tempResult);
            //}
            //else if (currentArie == 8)
            //{
            //    displayResultTextBlock.Text = converter.binaToDeci(tempResult);
            //}
            //else if (currentArie == 16)
            //{
            //    displayResultTextBlock.Text = converter.binaToHex(tempResult);
            //}
            //else
            //{
            //    displayResultTextBlock.Text = tempResult;
            //}
            //currentBinary = tempResult;
            #endregion

            // TODO: update the three displays
            if (!currentBinary.Contains("1"))
            {
                decimalDisplay.Text = "0";
                octalDisplay.Text = "0";
                hexDisplay.Text = "0";
            }
            else
            {
                decimalDisplay.Text = Trim(converter.binaToDeci(currentBinary));
                octalDisplay.Text = Trim(converter.binaToOcta(currentBinary));
                hexDisplay.Text = Trim(converter.binaToHex(currentBinary));
            }

        }

        private void BinaryOn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if ((bool)((ToggleButton)sender).IsChecked)
            {
                binaryDisplay.Visibility = Visibility.Visible;
                otherAriesDisplay.Visibility = Visibility.Collapsed;

                numberPads.Visibility = Visibility.Collapsed;
                threeDisplays.Visibility = Visibility.Visible;

                decimalDisplay.Text = calculator.CurrentOnScreen.ToString();
                octalDisplay.Text = converter.deciToOcta(calculator.CurrentOnScreen.ToString());
                hexDisplay.Text = converter.deciToHex(calculator.CurrentOnScreen.ToString());

                showBinaryInput.Begin();
                twoCom.IsEnabled = true;
            }
            else
            {
                otherAriesDisplay.Visibility = Visibility.Visible;
                binaryDisplay.Visibility = Visibility.Collapsed;

                numberPads.Visibility = Visibility.Visible;
                threeDisplays.Visibility = Visibility.Collapsed;

                calculator.CurrentOnScreen = Double.Parse(converter.binaToDeci(Trim(currentBinary)));
                if(currentArie == 8)
                {
                    displayResultTextBlock.Text = converter.deciToOcta(calculator.CurrentOnScreen.ToString());
                }
                else if(currentArie == 10)
                {
                    displayResultTextBlock.Text = calculator.CurrentOnScreen.ToString();
                }
                else if (currentArie == 16)
                {
                    displayResultTextBlock.Text = converter.deciToHex(calculator.CurrentOnScreen.ToString());
                }
                else
                {
                    displayResultTextBlock.Text = Trim(currentBinary);
                }

                twoCom.IsEnabled = false;
                hideBinaryInput.Begin();
            }
        }

        private void Arie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            #region Deci
            if (button.Tag.Equals("deci"))
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

                if(currentArie == 2)
                {
                    displayResultTextBlock.Text = converter.binaToDeci(displayResultTextBlock.Text);
                }
                else if(currentArie == 8)
                {
                    displayResultTextBlock.Text = converter.octaToDeci(displayResultTextBlock.Text);
                }
                else if(currentArie == 16)
                {
                    displayResultTextBlock.Text = converter.hexaToDeci(displayResultTextBlock.Text);
                }
                else
                {
                    // do nothing
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
                currentArie = 10;
            }
            #endregion
            #region Octa
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

                if (currentArie == 2)
                {
                    displayResultTextBlock.Text = converter.binaToOcta(displayResultTextBlock.Text);
                }
                else if (currentArie == 10)
                {
                    displayResultTextBlock.Text = converter.deciToOcta(displayResultTextBlock.Text);
                }
                else if (currentArie == 16)
                {
                    displayResultTextBlock.Text = converter.hexaToOcta(displayResultTextBlock.Text);
                }
                else
                {
                    // do nothing
                }
                // in case currentOnScreen is 0
                if (displayResultTextBlock.Text.Length < 1 || ulong.Parse(displayResultTextBlock.Text) == 0)
                {
                    displayResultTextBlock.Text = "0";
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
                currentArie = 8;
            }
            #endregion
            #region Hexa
            else if (button.Tag.Equals("hexa"))
            {
                Deci.IsChecked = false;
                Octa.IsChecked = false;
                Hexa.IsChecked = true;
                Bina.IsChecked = false;

                if (currentArie == 2)
                {
                    displayResultTextBlock.Text = converter.binaToHex(displayResultTextBlock.Text);
                }
                else if (currentArie == 8)
                {
                    displayResultTextBlock.Text = converter.octaToHex(displayResultTextBlock.Text);
                }
                else if (currentArie == 10)
                {
                    displayResultTextBlock.Text = converter.deciToHex(displayResultTextBlock.Text);
                }
                else
                {
                    // do nothing
                }
                if (displayResultTextBlock.Text.Length < 1)
                {
                    displayResultTextBlock.Text = "0";
                }

                if (numberPadHex.Visibility != Visibility.Visible)
                {
                    hideNumberPadDeci.Begin();
                    numberPadDeci.Visibility = Visibility.Collapsed;
                    numberPadHex.Visibility = Visibility.Visible;
                }

                currentArie = 16;
            }
            #endregion
            #region Bina
            else if (button.Tag.Equals("bina"))
            {
                Deci.IsChecked = false;
                Octa.IsChecked = false;
                Hexa.IsChecked = false;
                Bina.IsChecked = true;

                if (currentArie == 10)
                {
                    displayResultTextBlock.Text = Trim(converter.deciToBina(displayResultTextBlock.Text));
                }
                else if (currentArie == 8)
                {
                    displayResultTextBlock.Text = Trim(converter.octaToBina(displayResultTextBlock.Text));
                }
                else if (currentArie == 16)
                {
                    displayResultTextBlock.Text = Trim(converter.hexaToBina(displayResultTextBlock.Text));
                }
                else
                {
                    // do nothing
                }
                if (displayResultTextBlock.Text.Equals("0000") || displayResultTextBlock.Text.Equals("000") || displayResultTextBlock.Text.Equals("00") || displayResultTextBlock.Text.Equals("0") || displayResultTextBlock.Text.Equals(""))
                {
                    displayResultTextBlock.Text = "0";
                }

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
                currentArie = 2;
            }
            #endregion
        }

        private void Two_Com_Clicked(object sender, RoutedEventArgs e)
        {
            //Push_Toast();

            string tempBinary = "";
            while (currentBinary.Length < 64)
            {
                currentBinary = "0" + currentBinary;
            }
            for (int i = 0; i < 64; i++)
            {
                char thisDigit = currentBinary[i];
                if (thisDigit == '0')
                {
                    tempBinary += '1';
                }
                else
                {
                    tempBinary += '0';
                }
            }

            string currentDeciLocal = (ulong.Parse(converter.binaToDeci(tempBinary)) + 1).ToString();
            tempBinary = converter.deciToBina(currentDeciLocal);
            if(tempBinary.Length > 64)                      // get rid of the extra bits
                tempBinary = tempBinary.Substring(tempBinary.Length - 64);
            while (tempBinary.Length < 64)
            {
                tempBinary = "0" + tempBinary;
            }

            // Whether to disable other panels or not
            if ((bool)((ToggleButton)sender).IsChecked)                                         // Two's Complement Mode
            {
                decimalDisplay.Text = "N/A";
                octalDisplay.Text = "N/A";
                hexDisplay.Text = "N/A";
                BinaryOn.IsEnabled = false;

                Set_Bina_Pad_TapEnabled(false);
                Binary_Encode(tempBinary);
            }
            else                                                                                 // Normal Mode
            {
                currentDeciLocal = converter.binaToDeci(currentBinary);
                BinaryOn.IsEnabled = true;
                switch (currentArie)
                {
                    case 2:
                        displayResultTextBlock.Text = converter.deciToBina(currentDeciLocal);
                        break;
                    case 8:
                        displayResultTextBlock.Text = converter.deciToOcta(currentDeciLocal);
                        break;
                    case 16:
                        displayResultTextBlock.Text = converter.deciToHex(currentDeciLocal);
                        break;
                    case 10:
                        displayResultTextBlock.Text = currentDeciLocal;
                        break;
                }

                decimalDisplay.Text = currentDeciLocal;
                octalDisplay.Text = converter.deciToOcta(currentDeciLocal);
                hexDisplay.Text = converter.deciToHex(currentDeciLocal);
                Set_Bina_Pad_TapEnabled(true);
                Binary_Encode(currentBinary);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var key = (sender as Button).Content.ToString();
            string processText;

            switch (key)
            {
                #region fourOperations
                #region +
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
                        if(currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if(currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #region -
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
                        if (currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if (currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #region ×
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
                        if (currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if (currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #region ÷
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
                        if (currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if (currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #endregion

                #region utilityButtons
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
                        calculator.UpdateCurrent("0");
                        Update_Panels(displayResultTextBlock.Text);
                    }
                    else
                    {
                        displayResultTextBlock.Text = displayResultTextBlock.Text.Substring(0, displayResultTextBlock.Text.Length - 1);
                        calculator.UpdateCurrent(displayResultTextBlock.Text);
                        Update_Panels(displayResultTextBlock.Text);
                    }
                    break;
                case "=":
                    justPressedSign = false;
                    justPressedEquals = true;
                    processText = calculator.Equals();
                    Update_Panels(processText);

                    if (currentArie == 2)
                    {
                        displayProcessTextBlock.Text = converter.deciToBina(processText);
                    }
                    else if (currentArie == 8)
                    {
                        displayProcessTextBlock.Text = converter.deciToOcta(processText);
                    }
                    else if (currentArie == 16)
                    {
                        displayProcessTextBlock.Text = converter.deciToHex(processText);
                    }
                    else
                    {
                        displayProcessTextBlock.Text = processText;
                    }
                    displayResultTextBlock.Text = displayProcessTextBlock.Text;
                    break;
                case "C":
                    justPressedSign = false;
                    justPressedEquals = false;
                    displayProcessTextBlock.Text = "=";
                    displayResultTextBlock.Text = "0";
                    calculator.Initialise();                                                // initialise calculator
                    currentBinary = "";
                    for (int k = 0; k < 64; k++) { currentBinary += "0"; }                  // initialise currentBinary
                    Update_Panels("0");
                    break;
                #endregion

                #region numberButtons
                default:
                    if (justPressedEquals || displayResultTextBlock.Text.Equals("0") || displayResultTextBlock.Text.Equals("+") || displayResultTextBlock.Text.Equals("-") ||
                        displayResultTextBlock.Text.Equals("×") || displayResultTextBlock.Text.Equals("÷"))                         // just pressed signs or an initial state
                    {
                        displayResultTextBlock.Text = key;
                    }
                    else
                    {
                        displayResultTextBlock.Text += key;
                    }

                    if (currentArie == 2)
                    {
                        calculator.UpdateCurrent(converter.binaToDeci(displayResultTextBlock.Text));
                    }
                    else if (currentArie == 8)
                    {
                        calculator.UpdateCurrent(converter.octaToDeci(displayResultTextBlock.Text));
                    }
                    else if (currentArie == 16)
                    {
                        calculator.UpdateCurrent(converter.hexaToDeci(displayResultTextBlock.Text));
                    }
                    else
                    {
                        calculator.UpdateCurrent(displayResultTextBlock.Text);
                    }

                    justPressedSign = false;
                    justPressedEquals = false;
                    break;
                    #endregion
            }

            //currentDecimal = calculator.CurrentOnScreen.ToString();                          // could also just take from displayResultTextBlock.Text
            Update_Panels(displayResultTextBlock.Text);
            CheckSize();
        }

        private void Button_Click_Hex(object sender, RoutedEventArgs e)
        {
            // TODO:
            var key = (sender as Button).Content.ToString();
            string processText;

            switch (key)
            {
                #region fourOperations
                #region +
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
                        if (currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if (currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #region -
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
                        if (currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if (currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #region ×
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
                        if (currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if (currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #region ÷
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
                        if (currentArie == 2)
                        {
                            displayProcessTextBlock.Text = converter.deciToBina(processText);
                        }
                        else if (currentArie == 8)
                        {
                            displayProcessTextBlock.Text = converter.deciToOcta(processText);
                        }
                        else if (currentArie == 16)
                        {
                            displayProcessTextBlock.Text = converter.deciToHex(processText);
                        }
                        else
                        {
                            displayProcessTextBlock.Text = processText;
                        }
                    }
                    justPressedSign = true;
                    Update_Panels(displayProcessTextBlock.Text);
                    break;
                #endregion
                #endregion

                #region utilityButtons
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
                    else if (displayResultTextBlock.Text.Length < 2)
                    {
                        displayResultTextBlock.Text = "0";
                        calculator.UpdateCurrent("0");
                        Update_Panels(displayResultTextBlock.Text);
                    }
                    else
                    {
                        displayResultTextBlock.Text = displayResultTextBlock.Text.Substring(0, displayResultTextBlock.Text.Length - 1);
                        calculator.UpdateCurrent(displayResultTextBlock.Text);
                        Update_Panels(displayResultTextBlock.Text);
                    }
                    break;
                case "=":
                    justPressedSign = false;
                    justPressedEquals = true;
                    processText = calculator.Equals();
                    Update_Panels(processText);

                    if (currentArie == 2)
                    {
                        displayProcessTextBlock.Text = converter.deciToBina(processText);
                    }
                    else if (currentArie == 8)
                    {
                        displayProcessTextBlock.Text = converter.deciToOcta(processText);
                    }
                    else if (currentArie == 16)
                    {
                        displayProcessTextBlock.Text = converter.deciToHex(processText);
                    }
                    else
                    {
                        displayProcessTextBlock.Text = processText;
                    }
                    displayResultTextBlock.Text = displayProcessTextBlock.Text;
                    break;
                case "Clear":
                    justPressedSign = false;
                    justPressedEquals = false;
                    displayProcessTextBlock.Text = "=";
                    displayResultTextBlock.Text = "0";
                    calculator.Initialise();                                                // initialise calculator
                    currentBinary = "";
                    for (int k = 0; k < 64; k++) { currentBinary += "0"; }                  // initialise currentBinary
                    Update_Panels("0");
                    break;
                #endregion

                #region numberButtons
                default:
                    if (justPressedEquals || displayResultTextBlock.Text.Equals("0") || displayResultTextBlock.Text.Equals("+") || displayResultTextBlock.Text.Equals("-") ||
                        displayResultTextBlock.Text.Equals("×") || displayResultTextBlock.Text.Equals("÷"))                         // just pressed signs or an initial state
                    {
                        displayResultTextBlock.Text = key;
                    }
                    else
                    {
                        displayResultTextBlock.Text += key;
                    }

                    if (currentArie == 16)
                    {
                        calculator.UpdateCurrent(converter.hexaToDeci(displayResultTextBlock.Text));
                    }

                    justPressedSign = false;
                    justPressedEquals = false;
                    break;
                    #endregion
            }

            //currentDecimal = calculator.CurrentOnScreen.ToString();                          // could also just take from displayResultTextBlock.Text
            Update_Panels(displayResultTextBlock.Text);
            CheckSize();
        }

        private void Update_Panels(string currentOnDisplayResultTextBlock)
        {
            string deci = "0";

            // three displays
            if(currentArie == 2)
            {
                deci = converter.binaToDeci(currentOnDisplayResultTextBlock);
            }
            else if (currentArie == 8)
            {
                deci = converter.octaToDeci(currentOnDisplayResultTextBlock);
            }
            else if (currentArie == 10)
            {
                deci = currentOnDisplayResultTextBlock;
            }
            else if (currentArie == 16)
            {
                deci = converter.hexaToDeci(currentOnDisplayResultTextBlock);
            }

            ulong tempDeci;
            if(deci.Length > 15)
            {
                bool canParse = ulong.TryParse(deci, out tempDeci);
                decimalDisplay.Text = tempDeci.ToString("0.0##e+00");
            }
            else
            {
                decimalDisplay.Text = deci;
            }
            if (decimalDisplay.Text.Equals("0.0e+00"))
            {
                decimalDisplay.Text = "N/A";
            }

            string octal = converter.deciToOcta(currentOnDisplayResultTextBlock);
            if(octal.Length < 1)
            {
                octalDisplay.Text = "N/A";
            }
            else
            {
                octalDisplay.Text = octal;
            }

            string hex = converter.deciToHex(currentOnDisplayResultTextBlock);
            if(hex.Length < 1)
            {
                hexDisplay.Text = "N/A";
            }
            else
            {
                hexDisplay.Text = hex;
            }

            // binary panel
            string bina = "";
            if (currentArie == 10)
            {
                bina = converter.deciToBina(currentOnDisplayResultTextBlock);
            }
            else if (currentArie == 8)
            {
                bina = converter.octaToBina(currentOnDisplayResultTextBlock);
            }
            else if (currentArie == 16)
            {
                bina = converter.hexaToBina(currentOnDisplayResultTextBlock);
            }
            else
            {
                bina = currentOnDisplayResultTextBlock;
            }
            while (bina.Length < 64)
            {
                bina = "0" + bina;
            }

            Binary_Encode(bina);

            Get_Current_Binary();

            CheckSize();
        }

        private void Binary_Encode(string tempBinary)
        {
            #region binaryEncoding
            dig00.Text = tempBinary[63].ToString();
            dig01.Text = tempBinary[62].ToString();
            dig02.Text = tempBinary[61].ToString();
            dig03.Text = tempBinary[60].ToString();
            dig04.Text = tempBinary[59].ToString();
            dig05.Text = tempBinary[58].ToString();
            dig06.Text = tempBinary[57].ToString();
            dig07.Text = tempBinary[56].ToString();

            dig08.Text = tempBinary[55].ToString();
            dig09.Text = tempBinary[54].ToString();
            dig10.Text = tempBinary[53].ToString();
            dig11.Text = tempBinary[52].ToString();
            dig12.Text = tempBinary[51].ToString();
            dig13.Text = tempBinary[50].ToString();
            dig14.Text = tempBinary[49].ToString();
            dig15.Text = tempBinary[48].ToString();

            dig16.Text = tempBinary[47].ToString();
            dig17.Text = tempBinary[46].ToString();
            dig18.Text = tempBinary[45].ToString();
            dig19.Text = tempBinary[44].ToString();
            dig20.Text = tempBinary[43].ToString();
            dig21.Text = tempBinary[42].ToString();
            dig22.Text = tempBinary[41].ToString();
            dig23.Text = tempBinary[40].ToString();

            dig24.Text = tempBinary[39].ToString();
            dig25.Text = tempBinary[38].ToString();
            dig26.Text = tempBinary[37].ToString();
            dig27.Text = tempBinary[36].ToString();
            dig28.Text = tempBinary[35].ToString();
            dig29.Text = tempBinary[34].ToString();
            dig30.Text = tempBinary[33].ToString();
            dig31.Text = tempBinary[32].ToString();

            dig32.Text = tempBinary[31].ToString();
            dig33.Text = tempBinary[30].ToString();
            dig34.Text = tempBinary[29].ToString();
            dig35.Text = tempBinary[28].ToString();
            dig36.Text = tempBinary[27].ToString();
            dig37.Text = tempBinary[26].ToString();
            dig38.Text = tempBinary[25].ToString();
            dig39.Text = tempBinary[24].ToString();

            dig40.Text = tempBinary[23].ToString();
            dig41.Text = tempBinary[22].ToString();
            dig42.Text = tempBinary[21].ToString();
            dig43.Text = tempBinary[20].ToString();
            dig44.Text = tempBinary[19].ToString();
            dig45.Text = tempBinary[18].ToString();
            dig46.Text = tempBinary[17].ToString();
            dig47.Text = tempBinary[16].ToString();

            dig48.Text = tempBinary[15].ToString();
            dig49.Text = tempBinary[14].ToString();
            dig50.Text = tempBinary[13].ToString();
            dig51.Text = tempBinary[12].ToString();
            dig52.Text = tempBinary[11].ToString();
            dig53.Text = tempBinary[10].ToString();
            dig54.Text = tempBinary[9].ToString();
            dig55.Text = tempBinary[8].ToString();

            dig56.Text = tempBinary[7].ToString();
            dig57.Text = tempBinary[6].ToString();
            dig58.Text = tempBinary[5].ToString();
            dig59.Text = tempBinary[4].ToString();
            dig60.Text = tempBinary[3].ToString();
            dig61.Text = tempBinary[2].ToString();
            dig62.Text = tempBinary[1].ToString();
            dig63.Text = tempBinary[0].ToString();
            #endregion
        }

        private void Get_Current_Binary()
        {
            #region currentBinaryUpdate
            currentBinary = "";

            currentBinary += dig63.Text;
            currentBinary += dig62.Text;
            currentBinary += dig61.Text;
            currentBinary += dig60.Text;
            currentBinary += dig59.Text;
            currentBinary += dig58.Text;
            currentBinary += dig57.Text;
            currentBinary += dig56.Text;

            currentBinary += dig55.Text;
            currentBinary += dig54.Text;
            currentBinary += dig53.Text;
            currentBinary += dig52.Text;
            currentBinary += dig51.Text;
            currentBinary += dig50.Text;
            currentBinary += dig49.Text;
            currentBinary += dig48.Text;

            currentBinary += dig47.Text;
            currentBinary += dig46.Text;
            currentBinary += dig45.Text;
            currentBinary += dig44.Text;
            currentBinary += dig43.Text;
            currentBinary += dig42.Text;
            currentBinary += dig41.Text;
            currentBinary += dig40.Text;

            currentBinary += dig39.Text;
            currentBinary += dig38.Text;
            currentBinary += dig37.Text;
            currentBinary += dig36.Text;
            currentBinary += dig35.Text;
            currentBinary += dig34.Text;
            currentBinary += dig33.Text;
            currentBinary += dig32.Text;

            currentBinary += dig31.Text;
            currentBinary += dig30.Text;
            currentBinary += dig29.Text;
            currentBinary += dig28.Text;
            currentBinary += dig27.Text;
            currentBinary += dig26.Text;
            currentBinary += dig25.Text;
            currentBinary += dig24.Text;

            currentBinary += dig23.Text;
            currentBinary += dig22.Text;
            currentBinary += dig21.Text;
            currentBinary += dig20.Text;
            currentBinary += dig19.Text;
            currentBinary += dig18.Text;
            currentBinary += dig17.Text;
            currentBinary += dig16.Text;

            currentBinary += dig15.Text;
            currentBinary += dig14.Text;
            currentBinary += dig13.Text;
            currentBinary += dig12.Text;
            currentBinary += dig11.Text;
            currentBinary += dig10.Text;
            currentBinary += dig09.Text;
            currentBinary += dig08.Text;

            currentBinary += dig07.Text;
            currentBinary += dig06.Text;
            currentBinary += dig05.Text;
            currentBinary += dig04.Text;
            currentBinary += dig03.Text;
            currentBinary += dig02.Text;
            currentBinary += dig01.Text;
            currentBinary += dig00.Text;
            #endregion
        }

        private void CheckSize()
        {
            if (displayResultTextBlock.Text.Length >= 16)
            {
                displayResultTextBlock.FontSize = 24;
            }
            else
            {
                displayResultTextBlock.FontSize = 36;
            }

            if (displayProcessTextBlock.Text.Length >= 16)
            {
                displayProcessTextBlock.FontSize = 24;
            }
            else
            {
                displayProcessTextBlock.FontSize = 36;
            }

            if(converter.deciToOcta(displayResultTextBlock.Text).Length > 14 && !octalDisplay.Text.Equals("N/A"))
            {
                octalDisplay.FontSize = 26;
            }
            else
            {
                octalDisplay.FontSize = 40;
            }
        }

        private string Trim(string input)                   // to get rid of the 0s in the front
        {
            bool first = true;
            string newString = "";
            for(int i = 0; i < input.Length; i++)
            {
                if(!first || input[i] != '0')
                {
                    newString += input[i];
                    first = false;
                }
            }

            return newString;
        }

        private void Set_Bina_Pad_TapEnabled(bool input)
        {
            dig00.IsTapEnabled = input;
            dig01.IsTapEnabled = input;
            dig02.IsTapEnabled = input;
            dig03.IsTapEnabled = input;
            dig04.IsTapEnabled = input;
            dig05.IsTapEnabled = input;
            dig06.IsTapEnabled = input;
            dig07.IsTapEnabled = input;

            dig08.IsTapEnabled = input;
            dig09.IsTapEnabled = input;
            dig10.IsTapEnabled = input;
            dig11.IsTapEnabled = input;
            dig12.IsTapEnabled = input;
            dig13.IsTapEnabled = input;
            dig14.IsTapEnabled = input;
            dig15.IsTapEnabled = input;

            dig16.IsTapEnabled = input;
            dig17.IsTapEnabled = input;
            dig18.IsTapEnabled = input;
            dig19.IsTapEnabled = input;
            dig20.IsTapEnabled = input;
            dig21.IsTapEnabled = input;
            dig22.IsTapEnabled = input;
            dig23.IsTapEnabled = input;

            dig24.IsTapEnabled = input;
            dig25.IsTapEnabled = input;
            dig26.IsTapEnabled = input;
            dig27.IsTapEnabled = input;
            dig28.IsTapEnabled = input;
            dig29.IsTapEnabled = input;
            dig30.IsTapEnabled = input;
            dig31.IsTapEnabled = input;

            dig32.IsTapEnabled = input;
            dig33.IsTapEnabled = input;
            dig34.IsTapEnabled = input;
            dig35.IsTapEnabled = input;
            dig36.IsTapEnabled = input;
            dig37.IsTapEnabled = input;
            dig38.IsTapEnabled = input;
            dig39.IsTapEnabled = input;

            dig40.IsTapEnabled = input;
            dig41.IsTapEnabled = input;
            dig42.IsTapEnabled = input;
            dig43.IsTapEnabled = input;
            dig44.IsTapEnabled = input;
            dig45.IsTapEnabled = input;
            dig46.IsTapEnabled = input;
            dig47.IsTapEnabled = input;

            dig48.IsTapEnabled = input;
            dig49.IsTapEnabled = input;
            dig50.IsTapEnabled = input;
            dig51.IsTapEnabled = input;
            dig52.IsTapEnabled = input;
            dig53.IsTapEnabled = input;
            dig54.IsTapEnabled = input;
            dig55.IsTapEnabled = input;

            dig56.IsTapEnabled = input;
            dig57.IsTapEnabled = input;
            dig58.IsTapEnabled = input;
            dig59.IsTapEnabled = input;
            dig60.IsTapEnabled = input;
            dig61.IsTapEnabled = input;
            dig62.IsTapEnabled = input;
            dig63.IsTapEnabled = input;
        }

        //private void Push_Toast()
        //{
        //    // GeneratingToast Notification
        //    ToastTemplateType toastTemplate = ToastTemplateType.ToastText01;
        //    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

        //    XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
        //    toastTextElements[0].AppendChild(toastXml.CreateTextNode("Not available for fractionals"));

        //    //IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
        //    //((XmlElement)toastNode).SetAttribute("duration", "short");

        //    ToastNotification toast = new ToastNotification(toastXml);
        //    ToastNotificationManager.CreateToastNotifier().Show(toast);
        //}
    }
}
