using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//undo has gone too far
namespace RomanNumeralCnvrsn
{
    public class RomanNumeralCnvrsnVM : INotifyPropertyChanged
    {


        private int _integerNumeral = 0;
        private string _finalRomanNumeral = "";

        public int integerNumeral
        {
            get
            {
                return _integerNumeral;
            }

            set
            {
                _integerNumeral = value; NotifyPropertyChanged(); //notify XAML that the value has been changed
            }
        }

        public String finalString
        {
            get
            {
                return _finalRomanNumeral;
            }
            set
            {
                _finalRomanNumeral = value; NotifyPropertyChanged();
            }
        }

        public string Convert(int numeral)
        {
            
            int integerNumeral = numeral;
            string romanNumeral = "";

            if (integerNumeral >= 100)
            {
                romanNumeral = romanNumeral + "C";
                integerNumeral = integerNumeral - 100;
            }
            if (integerNumeral >= 90)
            {
                romanNumeral = romanNumeral + "XC";
                integerNumeral = integerNumeral - 90;
            }
            if (integerNumeral >= 50)
            {
                romanNumeral = romanNumeral + "L";
                integerNumeral = integerNumeral - 50;
            }
            if (integerNumeral >= 40)
            {
                romanNumeral = romanNumeral + "XL";
                integerNumeral = integerNumeral - 40;
            }
            while (integerNumeral >= 10)
            {
                romanNumeral = romanNumeral + "X";
                integerNumeral = integerNumeral - 10;
            }
            while (integerNumeral >= 9)
            {
                romanNumeral = romanNumeral + "IX";
                integerNumeral = integerNumeral - 9;
            }
            while (integerNumeral >= 5)
            {
                romanNumeral = romanNumeral + "V";
                integerNumeral = integerNumeral - 5;
            }
            while (integerNumeral >= 4)
            {
                romanNumeral = romanNumeral + "IV";
                integerNumeral = integerNumeral - 4;
            }
            while (integerNumeral >= 1)
            {
                romanNumeral = romanNumeral + "I";
                integerNumeral = integerNumeral - 1;
            }
            return romanNumeral;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) //somebody is listening? yes the xaml
            {
                //call them, and tell them something has been changed
                //we pass in the name of the property that is changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
