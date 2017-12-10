using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorldSeries
{
    public class WorldSeriesVM : INotifyPropertyChanged
    {
        private string _selectedTeam;
        private List<string> _listOfTeams = new List<string>();
        private List<string> _listSeriesWon = new List<string>();

        public string SelectedTeam
        {
            get
            {
                return _selectedTeam;
            }
            set
            {
                _selectedTeam = value;
                DisplaySeriesWon();
                NotifyPropertyChanged();
            }
        }
        public List<string> ListOfTeams
        {
            get
            {
                return _listOfTeams;
            }
            set
            {
                _listOfTeams = value;
                NotifyPropertyChanged();
            }
        }
        public List<string> ListSeriesWon
        {
            get
            {
                return _listSeriesWon;
            }
            set
            {
                _listSeriesWon = value;
                NotifyPropertyChanged();
            }
        }

        public WorldSeriesVM ()
        {
            List<string> temp = new List<string>();
            using (StreamReader sr = new StreamReader("../../text/Teams.txt"))
            {
                String currentLine;
                // Read the stream to a string, and write the string to the console.
                while ((currentLine = sr.ReadLine()) != null)
                {
                    temp.Add(currentLine);
                }
            }
            ListOfTeams = temp;
        }

        public void DisplaySeriesWon()
        {
            List<string> temp = new List<string>();
            int year = 1903;
            using (StreamReader sr = new StreamReader("../../text/WorldSeriesWinners.txt"))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (year == 1904 || year == 1994)
                    {
                        year++;
                    }
                    else
                    {
                        year++;
                    }
                    if (SelectedTeam == currentLine)
                    {
                        temp.Add(year.ToString());
                    }
                }
            }
            ListSeriesWon = temp;
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
