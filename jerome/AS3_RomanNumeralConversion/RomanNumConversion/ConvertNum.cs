using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace RomanNumConversion
{
    class ConvertNum: INotifyPropertyChanged
    {
        int _regnum;
        public int RegNum
        {
            get { return _regnum; }
            set { _regnum = value; NotifyPropertyChanged(); }
        }

        string [] _romannum = {"","I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X"};
        public string RomanNum
        {
            get { return _romannum[_regnum]; }
            set { _romannum[_regnum] = value; NotifyPropertyChanged(); }
        }

        public void RegNumToRomanNum()
        {
            RomanNum = _romannum[RegNum].ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
