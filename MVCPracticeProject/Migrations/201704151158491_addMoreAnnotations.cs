namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMoreAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Branches", "Address", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Branches", "Address", c => c.String());
            AlterColumn("dbo.Branches", "Name", c => c.String());
        }
    }
}
