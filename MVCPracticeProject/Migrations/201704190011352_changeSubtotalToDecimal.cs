namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSubtotalToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Subtotal", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Subtotal", c => c.Single(nullable: false));
        }
    }
}
