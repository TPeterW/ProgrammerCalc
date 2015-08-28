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
        string currentDecimal, currentBinary;
        int currentArie;

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
            currentArie = 10;

            // initialise currentBinary
            currentBinary = "";
            for(int i = 0; i < 64; i++)
            {
                currentBinary += "0";
            }
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
            string tempResult = "";

            if (((TextBlock)sender).Text == "0")
                ((TextBlock)sender).Text = "1";
            else
                ((TextBlock)sender).Text = "0";

            int position = 0;
            bool canParse = int.TryParse(((TextBlock)sender).Name.Substring(3, 2), out position);

            for (int i = 0; i < 64; i++)
            {
                if ((63 - i) == position)
                {
                    tempResult += ((TextBlock)sender).Text;
                }
                else
                {
                    tempResult += currentBinary[i];
                }
            }
            
            currentDecimal = converter.binaToDeci(tempResult);
            Update_Panels(currentDecimal);
            calculator.UpdateCurrent(currentDecimal);
            if(Deci.IsChecked == true)
            {
                displayResultTextBlock.Text = converter.binaToDeci(tempResult);
            }
            else if(Octa.IsChecked == true)
            {
                displayResultTextBlock.Text = converter.binaToDeci(tempResult);
            }
            else if(Hexa.IsChecked == true)
            {
                displayResultTextBlock.Text = converter.binaToHex(tempResult);
            }
            else
            {
                displayResultTextBlock.Text = tempResult;
            }
            currentBinary = tempResult;
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
                if (displayResultTextBlock.Text.Length < 1 || ulong.Parse(displayResultTextBlock.Text) == 0)
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
                    displayResultTextBlock.Text = converter.deciToBina(displayResultTextBlock.Text);
                }
                else if (currentArie == 8)
                {
                    displayResultTextBlock.Text = converter.octaToBina(displayResultTextBlock.Text);
                }
                else if (currentArie == 16)
                {
                    displayResultTextBlock.Text = converter.hexaToBina(displayResultTextBlock.Text);
                }
                else
                {
                    // do nothing
                }
                if (displayResultTextBlock.Text.Length < 1 || ulong.Parse(displayResultTextBlock.Text) == 0)
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

        private void twoComClicked(object sender, RoutedEventArgs e)
        {
            // TODO:
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
                    currentDecimal = "0";
                    currentBinary = "";
                    currentArie = 10;                                                       // back to base10
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
        }

        private void Update_Panels(string currentOnDisplayResultTextBlock)
        {
            // three displays
            string deci = currentOnDisplayResultTextBlock;
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
            #region binaryEncoding
            dig00.Text = bina[63].ToString();
            dig01.Text = bina[62].ToString();
            dig02.Text = bina[61].ToString();
            dig03.Text = bina[60].ToString();
            dig04.Text = bina[59].ToString();
            dig05.Text = bina[58].ToString();
            dig06.Text = bina[57].ToString();
            dig07.Text = bina[56].ToString();

            dig08.Text = bina[55].ToString();
            dig09.Text = bina[54].ToString();
            dig10.Text = bina[53].ToString();
            dig11.Text = bina[52].ToString();
            dig12.Text = bina[51].ToString();
            dig13.Text = bina[50].ToString();
            dig14.Text = bina[49].ToString();
            dig15.Text = bina[48].ToString();

            dig16.Text = bina[47].ToString();
            dig17.Text = bina[46].ToString();
            dig18.Text = bina[45].ToString();
            dig19.Text = bina[44].ToString();
            dig20.Text = bina[43].ToString();
            dig21.Text = bina[42].ToString();
            dig22.Text = bina[41].ToString();
            dig23.Text = bina[40].ToString();

            dig24.Text = bina[39].ToString();
            dig25.Text = bina[38].ToString();
            dig26.Text = bina[37].ToString();
            dig27.Text = bina[36].ToString();
            dig28.Text = bina[35].ToString();
            dig29.Text = bina[34].ToString();
            dig30.Text = bina[33].ToString();
            dig31.Text = bina[32].ToString();

            dig32.Text = bina[31].ToString();
            dig33.Text = bina[30].ToString();
            dig34.Text = bina[29].ToString();
            dig35.Text = bina[28].ToString();
            dig36.Text = bina[27].ToString();
            dig37.Text = bina[26].ToString();
            dig38.Text = bina[25].ToString();
            dig39.Text = bina[24].ToString();

            dig40.Text = bina[23].ToString();
            dig41.Text = bina[22].ToString();
            dig42.Text = bina[21].ToString();
            dig43.Text = bina[20].ToString();
            dig44.Text = bina[19].ToString();
            dig45.Text = bina[18].ToString();
            dig46.Text = bina[17].ToString();
            dig47.Text = bina[16].ToString();

            dig48.Text = bina[15].ToString();
            dig49.Text = bina[14].ToString();
            dig50.Text = bina[13].ToString();
            dig51.Text = bina[12].ToString();
            dig52.Text = bina[11].ToString();
            dig53.Text = bina[10].ToString();
            dig54.Text = bina[9].ToString();
            dig55.Text = bina[8].ToString();

            dig56.Text = bina[7].ToString();
            dig57.Text = bina[6].ToString();
            dig58.Text = bina[5].ToString();
            dig59.Text = bina[4].ToString();
            dig60.Text = bina[3].ToString();
            dig61.Text = bina[2].ToString();
            dig62.Text = bina[1].ToString();
            dig63.Text = bina[0].ToString();
            #endregion

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

            CheckSize();
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
    }
}
