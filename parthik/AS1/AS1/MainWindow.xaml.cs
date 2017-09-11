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

namespace AS1
{
    /// <summary>
    /// Identify the card clicked and display the text in label.
    /// </summary>
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //Function to display ace message
        private void display_ace(object sender, RoutedEventArgs e)
        {
            showText.Content = "Ace of Spades";
        }

        //Function to display jack message
        private void display_jack(object sender, RoutedEventArgs e)
        {
            showText.Content = "Jack of Clubs";
        }

        //Function to display joker message
        private void display_joker(object sender, RoutedEventArgs e)
        {
            showText.Content = "A Black Joker";
        }

        //Function to display king message
        private void display_king(object sender, RoutedEventArgs e)
        {
            showText.Content = "King of Diamonds";
        }

        //Function to display queen message
        private void display_queen(object sender, RoutedEventArgs e)
        {
            showText.Content = "Queen of Hearts";
        }
    }
}
