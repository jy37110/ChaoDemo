namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useMoneyType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dishes", "Price", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dishes", "Price", c => c.Double(nullable: false));
        }
    }
}
