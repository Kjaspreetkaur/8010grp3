
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DiceSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string DIRNAME = "Week 5";
        DiceVM dvm = new DiceVM();
        int count = 1;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = dvm;
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullpath = System.IO.Path.Combine(path, DIRNAME);
            Directory.CreateDirectory(fullpath);
            string filepath = System.IO.Path.Combine(fullpath, "x.txt");
            string output = null;
            
            dvm.Roll();

            output = "Roll " + count.ToString() + ": " + dvm.getRoll(dvm.FirstDie) + " " + dvm.getRoll(dvm.SecondDie) + Environment.NewLine;
            count++;
            File.AppendAllText(filepath, output);
        }
    }
}
