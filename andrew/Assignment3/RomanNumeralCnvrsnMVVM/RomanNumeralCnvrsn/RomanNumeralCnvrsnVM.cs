/** Roman Numeral Conversion - A3 - GRP3
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                _integerNumeral = value; NotifyPropertyChanged();
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

        public void Convert()
        {
            // Build the bigger numeral blocks
            if (integerNumeral >= 100)
            {
                finalString += "C";
                integerNumeral = integerNumeral - 100;
            }
            if (integerNumeral >= 90)
            {
                finalString += "XC";
                integerNumeral = integerNumeral - 90;
            }
            if (integerNumeral >= 50)
            {
                finalString += "L";
                integerNumeral = integerNumeral - 50;
            }
            if (integerNumeral >= 40)
            {
                finalString += "XL";
                integerNumeral = integerNumeral - 40;
            }
            // Want to repeatedly add the building blocks of smaller numerals
            while (integerNumeral >= 10)
            {
                finalString += "X";
                integerNumeral = integerNumeral - 10;
            }
            while (integerNumeral >= 9)
            {
                finalString += "IX";
                integerNumeral = integerNumeral - 9;
            }
            while (integerNumeral >= 5)
            {
                finalString += "V";
                integerNumeral = integerNumeral - 5;
            }
            while (integerNumeral >= 4)
            {
                finalString += "IV";
                integerNumeral = integerNumeral - 4;
            }
            while (integerNumeral >= 1)
            {
                finalString += "I";
                integerNumeral = integerNumeral - 1;
            }
        }
        
        //implement the interface
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
