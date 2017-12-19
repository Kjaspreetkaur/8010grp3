/** Assignment Week 10/11 - Employee Search
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;

namespace EmployeeSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeSearchVM esvm = new EmployeeSearchVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = esvm;
            esvm.HoldList = PopulateList();
            esvm.EmployeeList = esvm.HoldList;
        }

        public List<string> PopulateList()
        {
            const string CONNECT_STRING = @"Server=.\SQLEXPRESS;Database=Personnel.db3;Trusted_Connection=True;";
            List<string> temp = new List<string>();
            SqlConnection conn = new SqlConnection(CONNECT_STRING);
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM EMPLOYEE"; 
            cmd.ExecuteNonQuery(); 

            SqlDataReader dr = cmd.ExecuteReader(); 

            while (dr.Read())
            {
                temp.Add(dr.GetString(1).ToString() + " " +
                         dr.GetString(2).ToString() + " " +
                         dr.GetString(3).ToString() + " ");
            }
            dr.Close();

            return temp;
        }
    }
}
