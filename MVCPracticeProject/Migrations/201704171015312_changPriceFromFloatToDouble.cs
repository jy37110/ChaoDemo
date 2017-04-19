namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changPriceFromFloatToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dishes", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dishes", "Price", c => c.Single(nullable: false));
        }
    }
}
