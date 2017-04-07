namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "message", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "message", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
