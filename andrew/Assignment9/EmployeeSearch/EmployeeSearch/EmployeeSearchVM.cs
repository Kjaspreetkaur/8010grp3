/** Assignment Week 10/11 - Employee Search
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmployeeSearch
{
    public class EmployeeSearchVM : INotifyPropertyChanged
    {
        private List<string> _employeeList = new List<string>();
        private static List<string> _holdList = new List<string>();
        private string _searchQuery;

        public List<string> EmployeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                NotifyPropertyChanged();

            }
        }

        public List<string> HoldList
        {
            get;set;
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value.ToLower();
                NotifyPropertyChanged();
                Search();
            }
        }

        public void Search()
        {
            List<string> temp = new List<string>();
            foreach (string item in HoldList)
            {
                if (item.ToLower().Contains(SearchQuery))
                {
                    temp.Add(item);
                }
            }
            EmployeeList = temp;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
