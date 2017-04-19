namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changOrderItemClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "DishId", "dbo.Dishes");
            DropIndex("dbo.OrderItems", new[] { "DishId" });
            AddColumn("dbo.OrderItems", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "DishName", c => c.String(nullable: false));
            AddColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.OrderItems", "DishId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "DishId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderItems", "Price");
            DropColumn("dbo.OrderItems", "DishName");
            DropColumn("dbo.OrderItems", "Quantity");
            CreateIndex("dbo.OrderItems", "DishId");
            AddForeignKey("dbo.OrderItems", "DishId", "dbo.Dishes", "Id", cascadeDelete: true);
        }
    }
}
