namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdatedTile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TileType",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false),
                    Restriction = c.Boolean(nullable: false),
                    YearCreated = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);



        }

        public override void Down()
        {

            DropTable("dbo.TileType");
        }
    }
}
