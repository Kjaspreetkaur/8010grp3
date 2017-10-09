//Coins TO Dollar A3 Group 3
//Andrew 8113730
//Archit A. 8024168
//Parthik M. 8050213
//Bhumi S. 8022584
//Jaspreet K. 8051666
//Jerome S. 8055907

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoinsToDollar
{
    class coinsVM: INotifyPropertyChanged
    {
        const decimal PENNYVAL = 0.01m;
        const decimal NICKELVAL = 0.05m;
        const decimal DIMEVAL = 0.10m;        
        const decimal QUARTERVAL = 0.25m;

        decimal penny;
        decimal dime;
        decimal nickel;
        decimal quarter;

        public decimal Penny
        {
            get { return penny; }
            set { penny = value; NotifyPropertyChanged(); }
        }
                
        public decimal Dime
        {
            get { return dime; }
            set { dime = value; NotifyPropertyChanged(); }
        }
       
        public decimal Nickel
        {
            get { return nickel; }

            set { nickel = value; NotifyPropertyChanged(); }
        }

        public decimal Quarter
        {
            get { return quarter; }
            set { quarter = value; NotifyPropertyChanged(); }
        }

        decimal dollarTotal;
        public decimal DollarTotal
        {
            get { return dollarTotal; }
            set { dollarTotal = value; NotifyPropertyChanged(); }
        }

        public void AddCoins()
        {
            DollarTotal = (penny * PENNYVAL) + (nickel * NICKELVAL) + (dime * DIMEVAL) + (quarter * QUARTERVAL);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
