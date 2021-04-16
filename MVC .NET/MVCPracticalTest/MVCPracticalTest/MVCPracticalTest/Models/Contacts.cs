using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCPracticalTest.Models
{
    [Table("Contacts")]
    public class Contacts
    {
        public int Id { get; set; }

        [StringLength(100),Required]
       
        public string Name { get; set; }

        [StringLength(100),Required]
        public string Number { get; set; }

        [StringLength(100),Required]
        public string GroupName { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime BirthDay { get; set; }

    }
}