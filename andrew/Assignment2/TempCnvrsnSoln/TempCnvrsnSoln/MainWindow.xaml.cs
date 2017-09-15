/** Temperature Conversion
 * Assignment 2 - Group 3
 * Andrew Huynh 8113730
 */

using System.Windows;

namespace TempCnvrsnSoln
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCtoF_Click(object sender, RoutedEventArgs e)
        {
            decimal celcius = 0;
            decimal fahrenheit = 0;

            if (decimal.TryParse(tbxCelcius.Text, out celcius))
            {
                fahrenheit = decimal.Divide(9, 5) * celcius + 32;
                tbxCelcius.Text = celcius.ToString("N1") + "°C";
                lblCtoF.Content = fahrenheit.ToString("N1") + "°F";
            }

        }

        private void btnFtoC_Click(object sender, RoutedEventArgs e)
        {
            decimal celcius = 0;
            decimal fahrenheit = 0;

            if (decimal.TryParse(tbxFahrenheit.Text, out fahrenheit))
            {
                celcius = decimal.Divide(5, 9) * (fahrenheit - 32);
                tbxFahrenheit.Text = fahrenheit.ToString("N1") + "°F";
                lblFtoC.Content = celcius.ToString("N1") + "°C";
            }
        }

        private void btnResetCtoF_Click(object sender, RoutedEventArgs e)
        {
            lblCtoF.Content = "";
            tbxCelcius.Text = "";
        }

        private void btnResetFtoC_Click(object sender, RoutedEventArgs e)
        {
            lblFtoC.Content = "";
            tbxFahrenheit.Text = "";
        }
    }
}
