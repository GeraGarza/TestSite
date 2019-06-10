namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTileTable : DbMigration
    {
        public override void Up()
        {



            CreateTable(
                "dbo.Tiles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    DateAdded = c.DateTime(nullable: false),
                    AppOwner = c.String(nullable: false),
                    TileTypeId = c.Byte(nullable: false)

                })
                .PrimaryKey(t => t.Id);






        }

        public override void Down()
        {
        }
    }
}
