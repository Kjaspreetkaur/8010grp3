using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //Needed by INotifyPropertyChanged
using System.Runtime.CompilerServices; //Needed by CallerMemberName

namespace Week3
{
    class VM: INotifyPropertyChanged
    {
        private string _first;
        public string First
        {
            get { return _first; }
            set { _first = value; NotifyChanged(); }
        }

        private string _second;
        public string Second
        {
            get { return _second; }
            set { _second = value; NotifyChanged(); }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; NotifyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanged([CallerMemberName] String propertyName = "")
        {
           if (PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
