using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace numberConversion
{
    class NumConverter : INotifyPropertyChanged
    {
        private string _intVal;
        public string IntVal
        {
            get { return _intVal; }
            set { _intVal = value; NotifyPropertyChanged(); }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Converts numerals to roman
        public void Converter()
        {
           int intVal;
           if(int.TryParse(IntVal, out intVal))
            {
                Result = "";
                if(intVal>100 || intVal <= 0)
                {
                    Result = "Enter a number between 1-100.";
                }
                else
                {
                    while (intVal > 0)
                    {
                       if (intVal == 100)
                        {
                            Result += "C";
                            intVal -= 100;
                        }
                        else if (intVal >= 90)
                        {
                            Result += "XC";
                            intVal -= 90;
                        }
                        else if(intVal >= 50)
                        {
                            Result += "L";
                            intVal -= 50;
                        }
                        else if (intVal >= 40)
                        {
                            Result += "XL";
                            intVal -= 40;
                        }
                        else if (intVal >= 10)
                        {
                            Result += "X";
                            intVal -= 10;
                        }
                        else if(intVal >= 9)
                        {
                            Result += "IX";
                            intVal -= 9;
                        }
                        else if (intVal >= 5)
                        {
                            Result += "V";
                            intVal -= 5;
                        }
                        else if (intVal >= 4)
                        {
                            Result += "IV";
                            intVal -= 4;
                        }
                        else if (intVal >= 1)
                        {
                            Result += "I";
                            intVal -= 1;
                        }
                        else
                        {
                            Result = "Wrong Input";
                        }
                    }
                }
            }
            else
            {
                Result = "Enter a number.";
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
