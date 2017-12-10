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
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public Window1(string selected, List<PersonEntry> listOfEntries)
        {
            InitializeComponent();
            int counter = 0;
            PersonEntry pe = null;
            while (counter < listOfEntries.Count())
            {
                if (listOfEntries[counter].FullName == selected)
                {
                    pe = listOfEntries[counter];
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
