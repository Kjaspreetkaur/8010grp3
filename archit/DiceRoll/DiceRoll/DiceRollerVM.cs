﻿using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace DiceRoll
{
    class DiceRollerVM : INotifyPropertyChanged
    {
        const string IMG_EXT = ".bmp";
        const string IMG_PATH = "Images/Die";
        const string DIR_NAME = "RollData";
        const int RND_MIN = 1;
        const int RND_MAX = 7;

        Random rnd = new Random();

        private string dieOne;
        public string DieOne
        {
            get { return dieOne; }
            set { dieOne = value; NotifyPropertyChanged(); }
        }

        private string dieTwo;
        public string DieTwo
        {
            get { return dieTwo; }
            set { dieTwo = value; NotifyPropertyChanged(); }
        }

        private string txtContent;
        public string TxtContent
        {
            get { return txtContent; }
            set { txtContent = value; NotifyPropertyChanged(); }
        }

        public void DoTheRoll()
        {
            string randomOne = rnd.Next(RND_MIN, RND_MAX).ToString();
            string randomTwo = rnd.Next(RND_MIN, RND_MAX).ToString();
            DieOne = IMG_PATH + randomOne + IMG_EXT;
            DieTwo = IMG_PATH + randomTwo + IMG_EXT;
            SaveToFile(randomOne,randomTwo);
        }

        public void SaveToFile(string randomOne,string randomTwo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullpath = System.IO.Path.Combine(path, DIR_NAME);
            Directory.CreateDirectory(fullpath);
            File.AppendAllText(fullpath + "\\rollinfo.txt", DateTime.Now + "--> First: " + randomOne + " , Second: " + randomTwo + "\r\n");
        }

        public void ReadFromFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullpath = System.IO.Path.Combine(path, DIR_NAME);
            TxtContent = File.ReadAllText(fullpath + "\\rollinfo.txt");
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
