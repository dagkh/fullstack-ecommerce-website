namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateAvailabilityStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO AvailabilityStatus (Code, Name) 
            VALUES 
                ('AVAI', 'available'),
                ('SOLD', 'sold out')
                ");
        }

        public override void Down()
        {
            Sql("DELETE FROM AvailabilityStatus");
        }
    }
}
