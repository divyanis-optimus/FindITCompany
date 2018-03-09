using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CompanyLocator.Models
{
    public class Company
    {
        private string _mname;

        public string Name
        {
            get { return _mname; }
            set { _mname = value; }
        }

        private string _maddress;

        public string Address
        {
            get { return _maddress; }
            set { _maddress = value; }
        }



    }
}