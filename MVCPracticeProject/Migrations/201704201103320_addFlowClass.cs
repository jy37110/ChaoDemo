namespace MVCPracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFlowClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Flows");
        }
    }
}
