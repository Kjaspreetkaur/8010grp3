//Coins TO Dollar A3 Group 3
//Andrew 8113730
//Archit A. 8024168
//Parthik M. 8050213
//Bhumi S. 8022584
//Jaspreet K. 8051666
//Jerome S. 8055907

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
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace CoinsToDollar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        coinsVM cointotal = new coinsVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = cointotal;
        }

        // Create a timer
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        // The timer's Tick event
        private bool blinking = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (blinking)
            {
                lblWinner.Foreground = Brushes.White;
            }
            else
            {
                lblWinner.Foreground = Brushes.RoyalBlue;
            }
            blinking = !blinking;
        }

        //text pattern for all textboxes
        private string pattern = "^[0-9]";

        //check if entries made are non-numeric characters
        //Penny textbox
        private void tbxPenny_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearLblMsgs();

            Match m = Regex.Match(this.tbxPenny.Text, pattern);
            if (!m.Success)
                this.tbxPenny.Text = "";
        }
        //Nickel textbox
        private void tbxNickel_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearLblMsgs();

            Match m = Regex.Match(this.tbxNickel.Text, pattern);
            if (!m.Success)
                this.tbxNickel.Text = "";
        }
        //Dime textbox
        private void tbxDime_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearLblMsgs();

            Match m = Regex.Match(this.tbxDime.Text, pattern);
            if (!m.Success)
                this.tbxDime.Text = "";
        }
        //Quarter textbox
        private void tbxQrtr_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearLblMsgs();

            Match m = Regex.Match(this.tbxQrtr.Text, pattern);
            if (!m.Success)
                this.tbxQrtr.Text = "";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {   
            if (cointotal.Penny > 0 && cointotal.Dime > 0 && cointotal.Nickel > 0 && cointotal.Quarter > 0)
            {
                cointotal.AddCoins();
                if (cointotal.DollarTotal != 1)
                {
                    if (cointotal.DollarTotal > 1)
                        lblValidtnMsg.Content = "Total is more than $1. Try again!";
                    else
                        lblValidtnMsg.Content = "Total is less than $1. Try again!";
                }
                else
                {
                    lblWinner.Visibility = System.Windows.Visibility.Visible;
                    lblValidtnMsg.Content = "Total for all coins is $1.";
                }
            }
            else
                lblValidtnMsg.Content = "All coin types must have a value!";
        }

        //Initialize the textboxes to 0 and call function to clear all messages
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cointotal.Penny = 0;
            cointotal.Dime = 0;
            cointotal.Nickel = 0;
            cointotal.Quarter = 0;
            cointotal.DollarTotal = 0;
            clearLblMsgs();
        }

        //Clear all messages
        private void clearLblMsgs()
        {
            lblValidtnMsg.Content = "";
            lblWinner.Visibility = System.Windows.Visibility.Hidden;
        }

        //the following codes will select all text in the textbox by either tabbing or mouse-click
        private void tbxPenny_GotMouseCapture(object sender, MouseEventArgs e)
        {
            tbxPenny.SelectAll();
        }
        private void tbxPenny_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxPenny.SelectAll();
        }

        private void tbxDime_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxDime.SelectAll();
        }
        private void tbxDime_GotMouseCapture(object sender, MouseEventArgs e)
        {
            tbxDime.SelectAll();
        }

        private void tbxNickel_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxNickel.SelectAll();
        }
        private void tbxNickel_GotMouseCapture(object sender, MouseEventArgs e)
        {
            tbxNickel.SelectAll();
        }

        private void tbxQrtr_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxQrtr.SelectAll();
        }
        private void tbxQrtr_GotMouseCapture(object sender, MouseEventArgs e)
        {
            tbxQrtr.SelectAll();
        }
    }
}
