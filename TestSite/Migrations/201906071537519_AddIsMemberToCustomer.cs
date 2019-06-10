namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsMemberToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isMember", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "isMember");
        }
    }
}
