using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceSimulator
{
    public class DiceVM : INotifyPropertyChanged
    {
        Random r = new Random();
        private string _firstDie;
        private string _secondDie;

        public String FirstDie
        {
            get
            {
                return _firstDie;
            }
            set
            {
                _firstDie = value;
                NotifyPropertyChanged();
            }
        }
        public String SecondDie
        {
            get
            {
                return _secondDie;
            }
            set
            {
                _secondDie = value;
                NotifyPropertyChanged();
            }
        }

        public string Die()
        {
            int roll = (int)(r.NextDouble() * 7);

            while (roll < 1 || roll > 7)
            {
                roll = (int)(r.NextDouble()*7);
            }
            return SetDie(roll);
        }

        public String SetDie (int roll)
        {
            string setImg = null;
            switch (roll)
            {
                case (1):
                    setImg = "images/Die1.bmp";
                    break;
                case (2):
                    setImg = "images/Die2.bmp";
                    break;
                case (3):
                    setImg = "images/Die3.bmp";
                    break;
                case (4):
                    setImg = "images/Die4.bmp";
                    break;
                case (5):
                    setImg = "images/Die5.bmp";
                    break;
                default:
                    setImg = "images/Die6.bmp";
                    break;
            }
            return setImg;
        }

        public string getRoll(string image)
        {
            string roll = null;
            switch (image)
            {
                case ("images/Die1.bmp"):
                    roll = "1";
                    break;
                case ("images/Die2.bmp"):
                    roll = "2";
                    break;
                case ("images/Die3.bmp"):
                    roll = "3";
                    break;
                case ("images/Die4.bmp"):
                    roll = "4";
                    break;
                case ("images/Die5.bmp"):
                    roll = "5";
                    break;
                default:
                    roll = "6";
                    break;
            }
            return roll;
        }

        public void Roll()
        {
            FirstDie = Die();
            SecondDie = Die();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
