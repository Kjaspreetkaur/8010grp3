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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;

namespace WorldSeriesChamps
{
    class baseballWSVM : INotifyPropertyChanged
    {
        private List<string> teams = new List<string>();
        public List<string> Teams
        {
            get { return teams; }
            set { teams = value; NotifyPropertyChanged(); }
        }
       
        public void LoadListBox()
        {
            using (StreamReader r = new StreamReader("Teams.txt"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Teams.Add(line);
                }
            }
        }

        #region
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
