﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FptAptechEdu.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyConnection : DbContext
    {
        public MyConnection()
            : base("name=MyConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Course> Student_Course { get; set; }
    }
}
