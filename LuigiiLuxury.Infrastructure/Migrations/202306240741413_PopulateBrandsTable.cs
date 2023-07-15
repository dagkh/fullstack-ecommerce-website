namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBrandsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Brands (Id, Name) 
                VALUES
                    (1, 'alexander wang'),
                    (2, 'balenciaga'),
                    (3, 'burberry'),
                    (4, 'bvlgari'),
                    (5, 'celine'),
                    (6, 'dior'),
                    (7, 'dolce and gabbana'),
                    (8, 'fendi'),
                    (9, 'givenchy'),
                    (10, 'gucci'),
                    (11, 'loewe'),
                    (12, 'louis vuitton'),
                    (13, 'miu miu'),
                    (14, 'prada'),
                    (15, 'saint laurent'),
                    (16, 'luu vietanh')
                ");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Brands");
        }
    }
}
