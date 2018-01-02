/*System Dependencies - Final Assignment - GRP 3
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
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

namespace SystemDependencies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void btnSimulate_Click(object sender, RoutedEventArgs e)
        {
            vm.SimulateFromFile();
        }

        private void tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //vm.ReadArguments();
                //tbx.Clear();
            }        
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            vm.ReadArguments();
        }
    }
}
