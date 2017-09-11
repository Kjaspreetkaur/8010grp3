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

namespace SD_AS1_cardIdentifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();

            void btnCard1_Click(Object sender,
                           EventArgs e)
            {
                /*if (lblCard1.Text == "")
                    lblCard1.Text = "Ace of Spades";
                else
                    lblCard1.Text = "";*/
                MessageBox.Show("Hello");
            }
        }

       
    }
}
