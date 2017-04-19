namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDishAndOrderClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Details = c.String(),
                        Price = c.Single(nullable: false),
                        Type = c.String(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContextNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Status = c.String(),
                        Subtotal = c.Single(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Dishes", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Dishes", new[] { "Order_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Dishes");
        }
    }
}
