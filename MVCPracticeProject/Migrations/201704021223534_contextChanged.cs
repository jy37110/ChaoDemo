namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Hours = c.String(),
                        IsAgency = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        StockQty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.ProductBranches",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Branch_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Branch_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Branch_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Storages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Storages", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductBranches", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.ProductBranches", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductBranches", new[] { "Branch_Id" });
            DropIndex("dbo.ProductBranches", new[] { "Product_Id" });
            DropIndex("dbo.Storages", new[] { "BranchId" });
            DropIndex("dbo.Storages", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.ProductBranches");
            DropTable("dbo.Storages");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Branches");
        }
    }
}
