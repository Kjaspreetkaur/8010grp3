using System.Windows;

namespace RomanNumeralCnvrsn
{
    public partial class MainWindow : Window
    {
        RomanNumeralCnvrsnVM rmcVM = new RomanNumeralCnvrsnVM();

        public MainWindow()
        {
            InitializeComponent();
            rmcVM.integerNumeral = 1;
            rmcVM.finalString = "";
            DataContext = rmcVM;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            int integer = 0;

            //ensure the input was an integer
            if (int.TryParse(tbxGetInt.Text, out integer))
            {
                //ensure the input is a positive integer and within range 1-100
                if (integer <= 0 || integer > 100)
                {
                    MessageBox.Show("Please Enter a positive integer between 1-100.");
                }
                else
                {
                    //set variables
                    rmcVM.integerNumeral = integer;
                    rmcVM.finalString = rmcVM.Convert(integer);
                    imgTitus.Visibility = Visibility.Visible;
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
