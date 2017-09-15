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

namespace as1grp3
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

        private void clubs3_Click(object sender, RoutedEventArgs e)
        {
            CardName.Content = "Three of Clubs";
        }

        private void clubs7_Click(object sender, RoutedEventArgs e)
        {
            CardName.Content = "Seven of Clubs";
        }

        private void spadesAce_Click(object sender, RoutedEventArgs e)
        {
            CardName.Content = "Ace of Spades";
        }

        private void diamondsJack_Click(object sender, RoutedEventArgs e)
        {
            CardName.Content = "Jack of Diamonds";
        }

        private void heartsQueen_Click(object sender, RoutedEventArgs e)
        {
            CardName.Content = "Queen of Hearts";
        }
    }
}
