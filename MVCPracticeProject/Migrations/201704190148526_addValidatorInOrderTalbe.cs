namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidatorInOrderTalbe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Orders", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "PhoneNumber");
        }
    }
}
