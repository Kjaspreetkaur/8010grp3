using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AS2_tempConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConvertTemp converttemp;
        public MainWindow()
        {
            InitializeComponent();
            converttemp = new ConvertTemp();
            DataContext = converttemp;
        }

        private void btnCelsius_Click(object sender, RoutedEventArgs e)
        {
            //converttemp.ConvertToCelsius();
            tblkResult.Text = converttemp.ConvertToCelsius().ToString() + "°C";
        }

        private void btnFahrenheit_Click(object sender, RoutedEventArgs e)
        {
            //converttemp.ConvertToFahrenheit();
            tblkResult.Text = converttemp.ConvertToFahrenheit().ToString() + "°F";
        }
    }
}
