/*Hospital Charges A6 GRP3
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
using System.Text.RegularExpressions;

namespace HospitalCharges
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HospBillVM hospChargesVm = new HospBillVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = hospChargesVm;
        }

        //Set initial values for Admission/Discharge Dates using current date
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tblkAdmDate.Text = " " + DateTime.Today.ToString("yyyy-MM-dd");
            tblkDischgDate.Text = " " + DateTime.Today.ToString("yyyy-MM-dd");
        }

        //Select text in textboxes using tab key
        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        //Select text in textboxes using mouse click
        private void Mouse_GotMouseOver(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        //Validate text entered in text boxes
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Perform actions while entering data on current textbox 
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tbxName = ((TextBox)sender).Name;
            switch (tbxName)
            {
                case "tbxDays":
                    hospChargesVm.CalcStayCharges();
                    hospChargesVm.SetAdmDate();
                    break;
                case "tbxMeds": case "tbxSurgery": case "tbxLab": case "tbxRehab":
                    hospChargesVm.CalcMiscCharges();
                    break;
            }
            hospChargesVm.CalcTotalCharges();
        }
    }
}
