/** Hospital Charges A7 GRP3
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
using System.IO;

namespace WorldSeriesChamps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        baseballWSVM wsVM = new baseballWSVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = wsVM;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wsVM.LoadListBox();
        }

        private void lbTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTeam;
            string wsWins;
            string times;
            selectedTeam = lbTeams.SelectedItem.ToString();
            wsWins = checkWins(selectedTeam);
            tblkWonWS.Text = wsWins;
        }

        private string checkWins(string team)
        {
            int lineCount = 1902;
            int wsCount = 0;
            string wsYear = "";
            string wins = "";
            string times = "";
            string curTeam;
            using (StreamReader r = new StreamReader("WorldSeriesWinners.txt"))
            {
                while ((curTeam = r.ReadLine()) != null)
                {
                    lineCount++;
                    if (lineCount == 1904)
                        lineCount = 1905;
                    if (lineCount == 1994)
                        lineCount = 1995;
                    if (curTeam == team)
                    {
                        wsCount++;
                        if (wsCount > 1)
                            wsYear += ", " + lineCount.ToString();
                        else
                            wsYear = lineCount.ToString();
                    }   
                }
                r.Close();
            }
            if (wsCount > 1)
                times = " times";
            else
                times = " time";
            wins = wsCount.ToString() + times + " (" + wsYear + ")";
            if (wsCount == 0)
                wins = "Hasn't won the WS";
            return wins;
        }
    }
}