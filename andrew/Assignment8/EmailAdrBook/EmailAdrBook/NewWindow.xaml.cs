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
using System.Windows.Shapes;

namespace EmailAdrBook
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        public NewWindow()
        {
            InitializeComponent();
        }

        public NewWindow(string selected, List<PersonEntry> listOfEntries)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            int counter = 0;
            PersonEntry pe = null;

            while (counter < listOfEntries.Count())
            {
                if (listOfEntries[counter].FullName == selected)
                {
                    pe = listOfEntries[counter];
                    this.Title = pe.FullName + "'s Information"; //title of the window to be changed
                    lblFullname.Content = pe.FullName;
                    lblEmail.Content = pe.EmailAddr;
                    lblPhone.Content = pe.PhoneNum;
                    break;
                }
                else
                {
                    counter++;
                }
            }
        }
    }
}
