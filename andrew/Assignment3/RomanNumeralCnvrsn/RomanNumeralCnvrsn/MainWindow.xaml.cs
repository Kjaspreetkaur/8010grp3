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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tbxGetInt_KeyUp(object sender, KeyEventArgs e)
        {

            int integerNumeral = 0;
            string romanNumeral = "";
            /* taken from https://stackoverflow.com/questions/816334/wpf-a-textbox-that-has-an-event-that-fires-when-the-enter-key-is-pressed */
            if (e.Key != System.Windows.Input.Key.Enter)
            {
                return;
            }
            else
            {
                if (int.TryParse(tbxGetInt.Text, out integerNumeral))
                {
                    if (integerNumeral <= 0 || integerNumeral > 100)
                    {
                        MessageBox.Show("Please enter an integer from 1-100.");
                    }
                    else
                    {
                        if (integerNumeral >= 100)
                        {
                            romanNumeral = romanNumeral + "C";
                            integerNumeral = integerNumeral - 100;
                        }
                        if (integerNumeral >= 90)
                        {
                            romanNumeral = romanNumeral + "XC";
                            integerNumeral = integerNumeral - 90;
                        }
                        if (integerNumeral >= 50)
                        {
                            romanNumeral = romanNumeral + "L";
                            integerNumeral = integerNumeral - 50;
                        }
                        if (integerNumeral >= 40)
                        {
                            romanNumeral = romanNumeral + "XL";
                            integerNumeral = integerNumeral - 40;
                        }
                        while (integerNumeral >= 10)
                        {
                            romanNumeral = romanNumeral + "X";
                            integerNumeral = integerNumeral - 10;
                        }
                        while (integerNumeral >= 9)
                        {
                            romanNumeral = romanNumeral + "IX";
                            integerNumeral = integerNumeral - 9;
                        }
                        while (integerNumeral >= 5)
                        {
                            romanNumeral = romanNumeral + "V";
                            integerNumeral = integerNumeral - 5;
                        }
                        while (integerNumeral >= 4)
                        {
                            romanNumeral = romanNumeral + "IV";
                            integerNumeral = integerNumeral - 4;
                        }
                        while (integerNumeral >= 1)
                        {
                            romanNumeral = romanNumeral + "I";
                            integerNumeral = integerNumeral - 1;
                        }
                        tbxGetInt.Text = "";
                        lblRoman.Content = romanNumeral.ToString();
                        imgTitus.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a numerical integer from 1-100.");
                }
            }
        }
    }
}
