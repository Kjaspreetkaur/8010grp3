/** Dice Roll - A5 - GRP3
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
using System.Windows;

namespace DiceRoll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DiceRollerVM dr = new DiceRollerVM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = dr;
        }

        private void btnDiceRoll_Click(object sender, RoutedEventArgs e)
        {
            dr.DoTheRoll();
            showScroll.Visibility = Visibility.Hidden;
            dieOneImg.Visibility = Visibility.Visible;
            dieTwoImg.Visibility = Visibility.Visible;
        }

        private void btnShowContent_Click(object sender, RoutedEventArgs e)
        {
            dieOneImg.Visibility = Visibility.Hidden;
            dieTwoImg.Visibility = Visibility.Hidden;
            showScroll.Visibility = Visibility.Visible;
            dr.ReadFromFile();
        }
    }
}
