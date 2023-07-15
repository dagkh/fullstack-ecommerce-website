namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAnnotationOfAvailabilityStatusCodeColumnInProductsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "AvailabilityStatusCode", "dbo.AvailabilityStatus");
            DropIndex("dbo.Products", new[] { "AvailabilityStatusCode" });
            AlterColumn("dbo.Products", "AvailabilityStatusCode", c => c.String(maxLength: 4));
            CreateIndex("dbo.Products", "AvailabilityStatusCode");
            AddForeignKey("dbo.Products", "AvailabilityStatusCode", "dbo.AvailabilityStatus", "Code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "AvailabilityStatusCode", "dbo.AvailabilityStatus");
            DropIndex("dbo.Products", new[] { "AvailabilityStatusCode" });
            AlterColumn("dbo.Products", "AvailabilityStatusCode", c => c.String(nullable: false, maxLength: 4));
            CreateIndex("dbo.Products", "AvailabilityStatusCode");
            AddForeignKey("dbo.Products", "AvailabilityStatusCode", "dbo.AvailabilityStatus", "Code", cascadeDelete: true);
        }
    }
}
