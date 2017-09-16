using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AS2_tempConverter
{
    public class ConvertTemp : INotifyPropertyChanged
    {
        double _temp;
        double _tempconversion;

        //gets & sets the value of temperature to be converted
        public double Temp
        {
            get { return _temp; }
            set { _temp = value; NotifyPropertyChanged(); }
        }
        
        //Convert from Fahrenheit to Celsius
        public double ConvertToCelsius()
        {
            return Math.Round((_temp - 32) * 0.5555556,1);
        }

        //Convert from Celsius to Fahrenheit
        public double ConvertToFahrenheit()
        {
            return (_temp * 1.8) + 32;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
