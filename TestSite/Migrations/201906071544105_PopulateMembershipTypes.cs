namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO  MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO  MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (2,10,1,10)");
            Sql("INSERT INTO  MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (3,100,12,30)");

        }
        
        public override void Down()
        {
        }
    }
}
