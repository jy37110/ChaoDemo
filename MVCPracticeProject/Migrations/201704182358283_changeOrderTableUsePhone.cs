namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOrderTableUsePhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Phone", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "ContextNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ContextNumber", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "Phone");
        }
    }
}
