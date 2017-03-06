using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // check
            bool numbers = true;

            // get values, should check that are numbers
            double windowLength;
            double windowHeight;
            double kWidth;

            if (!double.TryParse(lengthTextBox.Text, out windowLength))
            {
                numbers = false;
            }
            if (!double.TryParse(heightTextBox.Text, out windowHeight))
            {
                numbers = false;
            }
            if (!double.TryParse(kWidthTextBox.Text, out kWidth))
            {
                numbers = false;
            }

            if (!numbers)
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Check Values!");
                await dialog.ShowAsync();
            }
            else
            {
                // check values
                if (windowLength < 2 * kWidth || windowHeight < 2 * kWidth)
                {
                    var dialog = new MessageDialog("Check Values (length or height can't smaller than 2*W)!");
                    await dialog.ShowAsync();
                }
                else
                {
                    // calc values
                    double windowArea = windowLength * windowHeight / 10; // cm^2
                    double classArea = (windowLength - 2 * kWidth) * (windowHeight - 2 * kWidth) / 10; // cm^2
                    double kCircuit = (windowLength * 2 + windowHeight * 2) / 10; // cm

                    // show values
                    windowAreaTextBox.Text = windowArea.ToString() + " cm^2";
                    classAreaTextBox.Text = classArea.ToString() + " cm^2";
                    kCircuitTextBox.Text = kCircuit + " cm";
                }
            }
        }
    }
}
