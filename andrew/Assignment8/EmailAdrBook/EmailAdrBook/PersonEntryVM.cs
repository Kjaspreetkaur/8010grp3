using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmailAdrBook
{
    public class PersonEntryVM : INotifyPropertyChanged
    {
        private List<string> _personList = new List<string>();
        private List<PersonEntry> _personEntryList = new List<PersonEntry>();

        private List<PersonEntry> PersonEntryList
        {
            get
            {
                return _personEntryList;
            }
            set
            {
                _personEntryList = value;
            }
        }

        private string _personSelected;

        public List<string> PersonList
        {
            get
            {
                return _personList;
            }
            set
            {
                _personList = value;
                NotifyPropertyChanged();
            }
        }

        public string PersonSelected
        {
            get
            {
                return _personSelected;
            }
            set
            {
                _personSelected = value;
                NotifyPropertyChanged();
                PopulateSelection();
            }
        }

        public void readFromFile ()
        {
            List<string> temp = new List<string>();
            List<PersonEntry> tempEntry = new List<PersonEntry>();
            PersonEntry pe = null;
            using (StreamReader sr = new StreamReader("../../People.txt"))
            {
                String currentLine;
                // Read the stream to a string, and write the string to the console.
                while ((currentLine = sr.ReadLine()) != null)
                {
                    pe = new PersonEntry();
                    pe.FullName = currentLine;
                    temp.Add(currentLine);

                    pe.EmailAddr = sr.ReadLine();
                    pe.PhoneNum = sr.ReadLine();
                    tempEntry.Add(pe);
                }
            }
            PersonList = temp;
            PersonEntryList = tempEntry;
        }

        public void PopulateSelection()
        {
            Window1 Window = new Window1(PersonSelected, PersonEntryList);
            Window.Show();
            Window.BringIntoView();
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
