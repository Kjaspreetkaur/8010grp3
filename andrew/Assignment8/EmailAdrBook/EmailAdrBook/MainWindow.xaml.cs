/** Assignment Week 9 - Email Address Book
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

namespace EmailAdrBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PersonEntryVM pevm = new PersonEntryVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = pevm;
            pevm.readFromFile();
            this.Closing += MainWindow_Closing;
        }

        //To close everything, when the main window closes
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
