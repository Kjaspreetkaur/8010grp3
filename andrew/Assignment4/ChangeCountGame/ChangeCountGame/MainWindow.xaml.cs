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

namespace ChangeCountGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChangeCounterVM ccVM = new ChangeCounterVM();
        public MainWindow()
        {
            InitializeComponent();
            ccVM.QuarterQuant = "0";
            ccVM.NickleQuant = "0";
            ccVM.DimeQuant = "0";
            ccVM.PennyQuant = "0";
            DataContext = ccVM;
        }

        private void Tbx_Keydown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)))
                e.Handled = true;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ccVM.Reset();
        }
    }
}
