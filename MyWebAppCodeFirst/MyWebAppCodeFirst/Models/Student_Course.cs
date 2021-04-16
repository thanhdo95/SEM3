using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebAppCodeFirst.Models
{
    public class Student_Course
    {
        [Key]
        public int EnrollID { get; set; }

        public int CourseID { get; set; }

        public int StudentID { get; set; }

        public decimal Grade { get; set; }

        public virtual Course Course {get; set ;}

        public virtual Student Student { get; set; }

        public virtual ICollection<Student_Course> Student_Courses { get; set; }
    }
}