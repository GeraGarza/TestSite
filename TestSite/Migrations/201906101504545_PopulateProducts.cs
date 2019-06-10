namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProducts : DbMigration
    {
        public override void Up()
        {


            Sql("SET IDENTITY_INSERT ProductTypes ON");
            Sql("INSERT INTO  ProductTypes (Id, Name, Restriction, YearCreated) VALUES (1,'Resource Management',0,2016)");
            Sql("INSERT INTO  ProductTypes (Id, Name, Restriction, YearCreated) VALUES (2,'Know My Sites',0,2016)");
            Sql("INSERT INTO  ProductTypes (Id, Name, Restriction, YearCreated) VALUES (3,'Maintenance Management',0, 2016)");
            Sql("INSERT INTO  ProductTypes (Id, Name, Restriction, YearCreated) VALUES (4,'Reduce Energy',0, 2016)");
            Sql("INSERT INTO  ProductTypes (Id, Name, Restriction, YearCreated) VALUES (5,'Reduce Energy',0, 2017)");
            Sql("INSERT INTO  ProductTypes (Id, Name, Restriction, YearCreated) VALUES (6,'Admin Access',1, 2019)");
            Sql("INSERT INTO  ProductTypes (Id, Name, Restriction, YearCreated) VALUES (7,'Monitor Performance',0, 2015)");

            

        }
        
        public override void Down()
        {
        }
    }
}
