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
using System.IO;

namespace DiceSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RollDiceVM rollDice = new RollDiceVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = rollDice;
        }

        const string DIR_NAME = "PROG8010-AS5";
        private void btnRollDice_Click(object sender, RoutedEventArgs e)
        {
            rollDice.RollDice();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullpath = System.IO.Path.Combine(path, DIR_NAME);
            Directory.CreateDirectory(fullpath);
            File.AppendAllText(fullpath + @"\x.txt", rollDice.Number1 + " / " + rollDice.Number2 + "\r\n");
        }
    }
}
