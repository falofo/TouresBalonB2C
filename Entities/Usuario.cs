using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Usuario
    {
        public string creditcardnumber { get; set; }
        public string creditcardtype { get; set; }
        public string custid { get; set; }
        public DateTime datelastlogin { get; set; }
        public string email { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string password { get; set; }
        public string phonenumber { get; set; }
        public string status { get; set; }
    }
}