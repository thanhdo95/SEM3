﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebAppCodeFirst.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Student_Course> Student_Courses { get; set; }
    }
}