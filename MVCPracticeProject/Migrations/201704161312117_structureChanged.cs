namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class structureChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dishes", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Dishes", new[] { "Order_Id" });
/*            RenameColumn(table: "dbo.OrderItems", name: "Order_Id", newName: "OrderId");*/
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DishId);
            
            DropColumn("dbo.Dishes", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "Order_Id", c => c.Int());
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "DishId", "dbo.Dishes");
            DropIndex("dbo.OrderItems", new[] { "DishId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.OrderItems");
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.Dishes", "Order_Id");
            AddForeignKey("dbo.Dishes", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
