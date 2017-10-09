using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows; 

namespace DiceSimulator
{
    class RollDiceVM : INotifyPropertyChanged
    {
        public string Number1;
        public string Number2;
        
        private string imageName1 = "images/die1.bmp";
        private string imageName2 = "images/die6.bmp";

        public string DispImage1
        {
            get { return imageName1; }
            set { imageName1 = value; PropertyChanged(this, new PropertyChangedEventArgs("DispImage1")); }
        }
        public string DispImage2
        {
            get { return imageName2; }
            set { imageName2 = value; PropertyChanged(this, new PropertyChangedEventArgs("DispImage2")); }
        }

        private int rand1;
        private int rand2;
        public void RollDice()
        {
            Random random = new Random();
            Number1 = random.Next(1, 7).ToString();
            Number2 = random.Next(1, 7).ToString();
            DispImage1 = "images/die" + Number1 + ".bmp";
            DispImage2 = "images/die" + Number2 + ".bmp";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
