using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group3
{
    class Employee
    {
        #region Properties
        #region EmployeeID
        private int empID;
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        #endregion

        #region Name
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region Position
        private string position;
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion

        #region HourRate
        private decimal hourRate;
        public decimal HourRate
        {
            get { return hourRate; }
            set { hourRate = value; }
        }
        #endregion
        #endregion
    }
}
