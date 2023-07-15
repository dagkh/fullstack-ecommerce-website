namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailabilityStatus",
                c => new
                {
                    Code = c.String(nullable: false, maxLength: 4),
                    Name = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Code);

            CreateTable(
                "dbo.Brands",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Countries",
                c => new
                {
                    Code = c.String(nullable: false, maxLength: 2),
                    Name = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Code);

            CreateTable(
                "dbo.OrderDetails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UnitPrice = c.Double(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Discount = c.Double(nullable: false),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Email = c.String(maxLength: 255),
                    ShipFullName = c.String(nullable: false, maxLength: 255),
                    ShipPhoneNumber = c.String(nullable: false, maxLength: 255),
                    ShipAddress = c.String(nullable: false, maxLength: 255),
                    ShipCity = c.String(nullable: false, maxLength: 255),
                    ShipRegion = c.String(nullable: false, maxLength: 255),
                    Note = c.String(),
                    OrderDate = c.DateTime(),
                    UserId = c.Int(),
                    CountryCode = c.String(nullable: false, maxLength: 2),
                    OrderStatusCode = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryCode, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusCode, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CountryCode)
                .Index(t => t.OrderStatusCode);

            CreateTable(
                "dbo.OrderStatus",
                c => new
                {
                    Code = c.String(nullable: false, maxLength: 100),
                    Name = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Code);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 255),
                    LastName = c.String(nullable: false, maxLength: 255),
                    Email = c.String(nullable: false, maxLength: 255),
                    Password = c.String(nullable: false, maxLength: 255),
                    PhoneNumber = c.String(maxLength: 15),
                    Address = c.String(),
                    City = c.String(maxLength: 255),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                    RoleCode = c.String(nullable: false, maxLength: 20),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleCode, cascadeDelete: true)
                .Index(t => t.RoleCode);

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    Code = c.String(nullable: false, maxLength: 20),
                    Name = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Code);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    NumberOfProducts = c.Int(),
                    Price = c.Double(nullable: false),
                    DiscountPrice = c.Double(),
                    Thumbnail = c.String(),
                    Description = c.String(),
                    Condition = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(),
                    IsDeleted = c.Boolean(),
                    AvailabilityStatusCode = c.String(nullable: false, maxLength: 4),
                    BrandId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AvailabilityStatus", t => t.AvailabilityStatusCode, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .Index(t => t.AvailabilityStatusCode)
                .Index(t => t.BrandId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "AvailabilityStatusCode", "dbo.AvailabilityStatus");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleCode", "dbo.Roles");
            DropForeignKey("dbo.Orders", "OrderStatusCode", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "CountryCode", "dbo.Countries");

            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "AvailabilityStatusCode" });
            DropIndex("dbo.Users", new[] { "RoleCode" });
            DropIndex("dbo.Orders", new[] { "OrderStatusCode" });
            DropIndex("dbo.Orders", new[] { "CountryCode" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });

            DropTable("dbo.Products");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Countries");
            DropTable("dbo.Brands");
            DropTable("dbo.AvailabilityStatus");
        }
    }
}
