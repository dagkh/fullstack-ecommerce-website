namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateRolesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Roles (Code, Name) 
            VALUES 
                ('admin', 'admin'),
                ('customer', 'customer')
                ");
        }

        public override void Down()
        {
            Sql("DELETE FROM Roles");
        }
    }
}
