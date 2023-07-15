namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateAdminAccount : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Users (RoleCode, FirstName, LastName, Email, Password, CreatedAt, IsDeleted) 
            VALUES 
                ('admin', 'Khoa', 'Dang Nguyen', 'admin@gmail.com', '21232f297a57a5a743894a0e4a801fc3', GETDATE(), 0)
                ");
        }

        public override void Down()
        {
            Sql("DELETE FROM Users WHERE RoleCode = 'admin'");
        }
    }
}
