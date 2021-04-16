using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Models
{
    public class Contact
    {
        public int id { get; set; }

        public string name { get; set; }

        public string number { get; set; }

        public string groupName { get; set; }

        public DateTime hireDate { get; set; }

        public DateTime birthDay { get; set; }
    }
}