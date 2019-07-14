namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedConstraintToNameApp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apps", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apps", "Name", c => c.String());
        }
    }
}
