namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedTiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tiles", "TileType_Id", "dbo.TileTypes");
            DropIndex("dbo.Tiles", new[] { "TileType_Id" });
            DropTable("dbo.Tiles");
            
        }
        
        public override void Down()
        {
           
            
            CreateTable(
                "dbo.Tiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        AppOwner = c.String(),
                        TileTypeId = c.Byte(nullable: false),
                        TileType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tiles", "TileType_Id");
            AddForeignKey("dbo.Tiles", "TileType_Id", "dbo.TileTypes", "Id");
        }
    }
}
