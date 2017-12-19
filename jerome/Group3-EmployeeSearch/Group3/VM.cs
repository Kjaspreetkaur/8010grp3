using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group3
{
    class VM : INotifyPropertyChanged
    {
        private List<Model> temp_EmployeeList;
        const string CONNECTION_STRING = @"Server=.\SQLEXPRESS01; Database=Personnel;Trusted_Connection=True";
        
        #region Properties
        #region EmployeeList
        private List<Model> employeeList;
        public List<Model> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region FilterName
        private string filterName;
        public string FilterName
        {
            get { return filterName; }
            set { filterName = value; FillData(filterName); NotifyPropertyChanged(); }
        }
        #endregion
        #endregion

        #region Methods
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region FillData()
        public void FillData(string Name)
        {
            using (SqlConnection sql_con = new SqlConnection(CONNECTION_STRING))
            {
                temp_EmployeeList = new List<Model>();
                sql_con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql_con;
                cmd.CommandText =  "SELECT ID,Name,Position,HourRate FROM Employee";
                cmd.CommandText += " WHERE Name LIKE '%" + Name.Trim() + "%'";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();//Instantiating the Employee class
                    emp.EmpID = (int)(dr["ID"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Position = dr["Position"].ToString();
                    emp.HourRate = (decimal)(dr["HourRate"]);

                    Model m = new Model();
                    m.Emp = emp;
                    temp_EmployeeList.Add(m);
                }
                dr.Close();
                EmployeeList = temp_EmployeeList;
            }
        }
        #endregion

        #region Constructor VM()
        public VM()
        {
            EmployeeList = new List<Model>();
            temp_EmployeeList = new List<Model>();
            FillData(string.Empty);
        }
        #endregion      
        #endregion
    }
}
