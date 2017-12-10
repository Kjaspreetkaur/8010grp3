using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAdrBook
{
    public class PersonEntry
    {
        private string _fullName;
        private string _emailAddr;
        private string _phoneNum;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
            }
        }

        public string EmailAddr
        {
            get
            {
                return _emailAddr;
            }
            set
            {
                _emailAddr = value;
            }
        }

        public string PhoneNum
        {
            get
            {
                return _phoneNum;
            }
            set
            {
                _phoneNum = value;
            }
        }

        public override string ToString()
        {
            return "Name: " + FullName + System.Environment.NewLine
                + "Email Address: " + EmailAddr + System.Environment.NewLine 
                + "Phone Number: " + PhoneNum + System.Environment.NewLine;
        }
    }
}
