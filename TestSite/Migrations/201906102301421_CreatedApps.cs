namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedApps : DbMigration
    {
        public override void Up()
        {


            CreateTable(
                "dbo.ProductTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Resrtiction = c.Boolean(),
                    YearCreated = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

          






            RenameTable(name: "dbo.ProductTypes", newName: "AppTypes");
          
           
            CreateTable(
                "dbo.Apps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        AppOwner = c.String(),
                        AppTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppTypes", t => t.AppTypeId, cascadeDelete: true)
                .Index(t => t.AppTypeId);
            
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        AppOwner = c.String(),
                        ProductTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Apps", "AppTypeId", "dbo.AppTypes");
            DropIndex("dbo.Apps", new[] { "AppTypeId" });
            DropTable("dbo.Apps");
            CreateIndex("dbo.Products", "ProductTypeId");
            AddForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.AppTypes", newName: "ProductTypes");


            
            
        }
    }
}
