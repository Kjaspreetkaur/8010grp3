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

namespace RomanNumeralCnvrsn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RomanNumeralCnvrsnVM rmcVM = new RomanNumeralCnvrsnVM();
        public MainWindow()
        {
            InitializeComponent();
            rmcVM.integerNumeral = 1;
            rmcVM.finalString = "";
            /*
            int integer = 0;

            if (int.TryParse(tbxGetInt.Text, out integer))
            {
                rmcVM.integerNumeral = integer;
            }
            rmcVM.finalString = ""; */
            DataContext = rmcVM;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            int integer = 0;

            if (int.TryParse(tbxGetInt.Text, out integer))
            {
                if (integer <= 0 || integer > 100)
                {
                    MessageBox.Show("Please Enter a positive integer between 1-100.");
                }
                else
                {
                    rmcVM.integerNumeral = integer;
                    rmcVM.finalString = rmcVM.Convert(integer);
                    imgTitus.Visibility = Visibility.Visible;
                    //lblRoman.Content = rmcVM.finalString;
                }
            }
            else
            {
                MessageBox.Show("Please enter an integer between 1-100.");
            }
        }


        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lblRoman.Content = "";
            tbxGetInt.Text = "";
            imgTitus.Visibility = Visibility.Hidden;
        }
    }
}
