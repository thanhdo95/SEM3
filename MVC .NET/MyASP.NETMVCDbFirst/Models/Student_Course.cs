namespace MyASP.NETMVCDbFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edu.Student_Course")]
    public partial class Student_Course
    {
        [Key]
        public int EnrollID { get; set; }

        public decimal? GRADE { get; set; }

        public int ID { get; set; }

        public int courseID { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
