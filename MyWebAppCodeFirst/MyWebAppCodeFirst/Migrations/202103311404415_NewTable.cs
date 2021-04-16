namespace MyWebAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Student_Course",
                c => new
                    {
                        EnrollID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Student_Course_EnrollID = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Student_Course", t => t.Student_Course_EnrollID)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID)
                .Index(t => t.Student_Course_EnrollID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student_Course", "Student_Course_EnrollID", "dbo.Student_Course");
            DropForeignKey("dbo.Student_Course", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Student_Course", "CourseID", "dbo.Courses");
            DropIndex("dbo.Student_Course", new[] { "Student_Course_EnrollID" });
            DropIndex("dbo.Student_Course", new[] { "StudentID" });
            DropIndex("dbo.Student_Course", new[] { "CourseID" });
            DropTable("dbo.Students");
            DropTable("dbo.Student_Course");
            DropTable("dbo.Courses");
        }
    }
}
