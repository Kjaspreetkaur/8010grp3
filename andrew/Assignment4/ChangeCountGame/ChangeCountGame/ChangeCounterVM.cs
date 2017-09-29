using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCountGame
{
    class ChangeCounterVM : INotifyPropertyChanged
    {
        const int QUARTER = 25;
        const int DIME = 10;
        const int NICKLE = 5;
        const int PENNY = 1;
        const int DOLLAR = 100;

        private string _quarterQuant;
        private string _dimeQuant;
        private string _nickleQuant;
        private string _pennyQuant;
        private string _message;

        public event PropertyChangedEventHandler PropertyChanged;

        public String QuarterQuant
        {
            get
            {
                return _quarterQuant;
            }
            set
            {
                _quarterQuant = value;
                CheckDollar();
                NotifyPropertyChanged();
            }
        }
        public String DimeQuant
        {
            get
            {
                return _dimeQuant;
            }
            set
            {
                _dimeQuant = value;
                CheckDollar();
                NotifyPropertyChanged();
            }
        }
        public String NickleQuant
        {
            get
            {
                return _nickleQuant;
            }
            set
            {
                _nickleQuant = value;
                CheckDollar();
                NotifyPropertyChanged();
            }
        }
        public String PennyQuant
        {
            get
            {
                return _pennyQuant;
            }
            set
            {
                _pennyQuant = value;
                CheckDollar();
                NotifyPropertyChanged();
            }
        }
        public String Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                NotifyPropertyChanged();
            }
        }



        public int CheckInt(string tocheck)
        {
            int integer = 0;
            if (int.TryParse(tocheck, out integer))
            {
                return integer;
            }
            else {
                return 0;
            }
        }

        public void Reset()
        {
            QuarterQuant = "0";
            DimeQuant = "0";
            NickleQuant = "0";
            PennyQuant = "0";
            Message = "";
        }

        public void CheckDollar()
        {
            int qQuarters = CheckInt(QuarterQuant);
            int qDimes = CheckInt(DimeQuant);
            int qNickles = CheckInt(NickleQuant);
            int qPennies = CheckInt(PennyQuant);
            int total = 0;

            total = qQuarters * QUARTER + qDimes * DIME + qNickles * NICKLE + qPennies * PENNY;

            if (total == DOLLAR)
            {
                Message = "Winner! You've got a dollar!";
            }
            else if (total < DOLLAR)
            {
                Message = "You've got less than a dollar!";
            }
            else
            {
                Message = "You've got more than a dollar!";
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
