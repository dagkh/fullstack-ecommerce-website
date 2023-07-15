namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCreatedAtColumnAndUpdatedAtColumnInProductsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "CreatedAt");
            DropColumn("dbo.Products", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Products", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
