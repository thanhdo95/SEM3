using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebAppCodeFirst.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<Student_Course> Student_Courses { get; set; }
    }
}