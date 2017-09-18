/** Temperature Conversion-A2-GRP3
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */

using System.Windows;
using System.Windows.Media;

namespace tempConversion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void convert_to_celsius(object sender, RoutedEventArgs e)
        {
            try
            {
                double fahrenheit = double.Parse(tbxF.Text);
                double celsius = (5.0 / 9.0) * (fahrenheit - 32.0);
                lblConvertedC.Content = celsius.ToString("F1") + "°C";
                lblOriginalF.Content = fahrenheit.ToString("F1") + "°F";
                fill_thermometer(celsius);
                reset_convert_to_fahrenheit();
            }
            catch
            {
                lblThermo.Foreground = Brushes.Red;
                reset_convert_to_celsius();
                reset_convert_to_fahrenheit();
                fill_thermometer(200.0);
                lblThermo.Content = "WRONG INPUT";
            }
        }

        private void convert_to_fahrenheit(object sender, RoutedEventArgs e)
        {
            try
            {
                double celsius = double.Parse(tbxC.Text);
                double fahrenheit = (9.0 / 5.0) * celsius + 32.0;
                lblConvertedF.Content = fahrenheit.ToString("F1") + "°F";
                lblOriginalC.Content = celsius.ToString("F1") + "°C";
                fill_thermometer(celsius);
                reset_convert_to_celsius();
            }
            catch
            {
                lblThermo.Foreground = Brushes.Red;
                reset_convert_to_celsius();
                reset_convert_to_fahrenheit();
                fill_thermometer(200.0);
                lblThermo.Content = "WRONG INPUT";
            }
        }

        private void fill_thermometer(double celsius)
        {
            if (celsius > 100 || celsius <= -100)
            {
                lblConvertedC.FontSize = lblConvertedF.FontSize = 20;
                lblOriginalC.FontSize = lblOriginalF.FontSize = 16;
                thermometer.Height = 230;
                thermometer.Background = Brushes.LightGray;
                lblThermo.Content = "Extreme.";
            }
            else
            {
                lblConvertedC.FontSize = lblConvertedF.FontSize = 36;
                lblOriginalC.FontSize = lblOriginalF.FontSize = 24;

                if (celsius <= 0)
                {
                    thermometer.Height = (100 + celsius) * (1.2);
                    thermometer.Background = Brushes.DarkSlateBlue;
                    lblThermo.Content = "Freezing.";
                }
                else if (celsius > 0 && celsius <= 20)
                {
                    thermometer.Height = celsius * 1.2 + 120;
                    thermometer.Background = Brushes.SkyBlue;
                    lblThermo.Content = "Cold.";
                }
                else if (celsius > 20 && celsius <60)
                {
                    thermometer.Height = celsius * 1.2 + 120;
                    thermometer.Background = Brushes.Orange;
                    lblThermo.Content = "Moderate!";
                }
                else
                {
                    thermometer.Height = celsius * 1.2 + 120;
                    thermometer.Background = Brushes.OrangeRed;
                    lblThermo.Content = "Hot!";
                }
                    
            }

        }

        private void reset_convert_to_celsius()
        {
            lblConvertedC.Content = "Enter and Click!";
            lblConvertedC.FontSize = 16;
            lblOriginalF.Content = tbxF.Text = tbxC.Text = string.Empty;
        }

        private void reset_convert_to_fahrenheit()
        {
            lblConvertedF.Content = "Enter and Click!";
            lblConvertedF.FontSize = 16;
            lblOriginalC.Content = tbxF.Text = tbxC.Text = string.Empty;
        }
    }
}
