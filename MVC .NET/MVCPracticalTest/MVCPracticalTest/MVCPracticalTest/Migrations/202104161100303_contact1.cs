namespace MVCPracticalTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "Number", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "GroupName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "GroupName", c => c.String());
            AlterColumn("dbo.Contacts", "Number", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
        }
    }
}
