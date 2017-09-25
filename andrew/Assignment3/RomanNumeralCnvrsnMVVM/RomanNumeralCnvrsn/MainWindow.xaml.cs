/** Roman Numeral Conversion - A3 - GRP3
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
using System.Windows;

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
            /*
             * Initialize the VM class, set default variables
             */
            InitializeComponent();
            DataContext = rmcVM;
        }

        //Convert click
        //Checks user input, then sets default variables before calling method Convert()
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            int integer = 0;

            if (int.TryParse(tbxGetInt.Text, out integer))
            {
                if (integer <= 0 || integer > 100)
                {
                    MessageBox.Show("Please Enter a positive integer between 1-100.");
                    tbxGetInt.Focus();
                    tbxGetInt.Text = "";
                    rmcVM.finalString = "";
                }
                else
                {
                    //set user input and initial string
                    rmcVM.integerNumeral = integer;
                    rmcVM.finalString = "";

                    //call method
                    rmcVM.Convert();

                    imgTitus.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Please enter an integer between 1-100.");
                tbxGetInt.Focus();
                tbxGetInt.Text = "";
                rmcVM.finalString = "";
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
