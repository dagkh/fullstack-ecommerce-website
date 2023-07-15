namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateProductsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Products (IsDeleted, NumberOfProducts, AvailabilityStatusCode, BrandId, Name, Thumbnail, Price) 
                VALUES
                    (0, 1, 'AVAI', 1, 'ALEXANDER WANG Attica Embellished Solf Leather Belt Bag', '/Images/UploadProductImages/ALEXANDERWANG-Attica-Embellished-Solf-Leather-Belt-Bag.jpg', 320),

                    (0, 1, 'AVAI', 3, 'BURBERRY Hackberry Monogram Small Brown Shoulder Bag', '/Images/UploadProductImages/BURBERRY-Hackberry-Monogram-Small-Brown-Shoulder-Bag.jpg', 610),
                    (0, 1, 'AVAI', 3, 'BURBERRY Monogram Stripe Canvas Tote Bag', '/Images/UploadProductImages/BURBERRY-Monogram-Stripe-Canvas-Tote-Bag.jpg', 450),
                    (0, 1, 'AVAI', 3, 'BURBERRY Trench Calfskin Splash Top Handle Bag', '/Images/UploadProductImages/BURBERRY-Trench-Calfskin-Splash-Top-Handle-Bag.jpg', 400),

                    (0, 1, 'AVAI', 4, 'BVLGARI Serpenti Forever Calfskin Leather Shoulder Bag', '/Images/UploadProductImages/BVLGARI-Serpenti-Forever-Calfskin-Leather-Shoulder-Bag.jpg', 180),
                    (0, 1, 'AVAI', 4, 'BVLGARI Serpenti Forever Calfskin Leather Shoulder Bag', '/Images/UploadProductImages/BVLGARI-Serpenti-Forever-Calfskin-Leather-Shoulder-Bag-Green.jpg', 310),
                    (0, 1, 'AVAI', 4, 'BVLGARI Serpenti Forever Calfskin Leather Shoulder Bag', '/Images/UploadProductImages/BVLGARI-Serpenti-Forever-Calfskin-Leather-Shoulder-Bag-Orange.jpg', 340),

                    (0, 1, 'AVAI', 6, 'C.DIOR Solf Pouch', '/Images/UploadProductImages/DIOR-Solf-Pouch.jpg', 650),

                    (0, 1, 'AVAI', 5, 'CELINE Frame Leather Shoulder Bag', '/Images/UploadProductImages/CELINE-Frame-Leather-Shoulder-Bag.jpg', 120),
                    (0, 1, 'AVAI', 5, 'CELINE Pony Hair Calfskin Diamond Compact Multifunction Wallet - Pearl Grey', '/Images/UploadProductImages/CELINE-Pony-Hair-Calfskin-Diamond-Compact-Multifunction-Wallet-Pearl-Grey.jpg', 340),
                    (0, 1, 'AVAI', 5, 'CELINE Triomphe Monogram Calfskin Phone Pouch', '/Images/UploadProductImages/CELINE-Triomphe-Monogram-Calfskin-Phone-Pouch.jpg', 120),
                    (0, 1, 'AVAI', 5, 'CELINE Trotteur Crossbody Bag', '/Images/UploadProductImages/CELINE-Trotteur-Crossbody-Bag.jpg', 270),

                    (0, 1, 'AVAI', 7, 'D&G Appliqué Leather Pouch', '/Images/UploadProductImages/D&G-Appliqué-Leather-Pouch.jpg', 210),

                    (0, 1, 'AVAI', 8, 'FENDI Peekaboo Orchid Mini Bag', '/Images/UploadProductImages/FENDI-Peekaboo-Orchid-Mini-Bag.jpg', 810),

                    (0, 1, 'AVAI', 9, 'GIVENCHY Easy Tri-tone Leather Tote', '/Images/UploadProductImages/GIVENCHY-Easy-Tri-tone-Leather-Tote.jpg', 480),
                    (0, 1, 'AVAI', 9, 'GIVENCHY GV3 Medium Leather Crossbody Bag', '/Images/UploadProductImages/GIVENCHY-GV3-Medium-Leather-Crossbody-Bag.jpg', 450),
                    (0, 1, 'AVAI', 9, 'GIVENCHY Large Star Athlete Zip Pouch Bag', '/Images/UploadProductImages/GIVENCHY-Large-Star-Athlete-Zip-Pouch-Bag.jpg', 100),

                    (0, 1, 'AVAI', 10, 'GUCCI Guccissima Leather Shoulder Bag', '/Images/UploadProductImages/GUCCI-Guccissima-Leather-Shoulder-Bag.jpg', 650),
                    (0, 1, 'AVAI', 10, 'GUCCI Mens Leather Wallet', '/Images/UploadProductImages/GUCCI-Mens-Leather-Wallet.jpg', 150),
                    (0, 1, 'AVAI', 10, 'GUCCI Monogram Canvas Belt Bag', '/Images/UploadProductImages/GUCCI-Monogram-Canvas-Belt-Bag.jpg', 380),
                    (0, 1, 'AVAI', 10, 'GUCCI Supreme Canvas Bi-fold Wallet ', '/Images/UploadProductImages/GUCCI-Supreme-Canvas-Bi-fold-Wallet.jpg', 700),

                    (0, 1, 'AVAI', 11, 'LOEWE Black Textured Goya Simple Briefcase', '/Images/UploadProductImages/LOEWE-Black-Textured-Goya-Simple-Briefcase.jpg', 650),
                    (0, 1, 'AVAI', 11, 'LOEWE Bucket Bag', '/Images/UploadProductImages/LOEWE-Bucket-Bag.jpg', 360),

                    (0, 1, 'AVAI', 12, 'LV Burgundy Sarah Maroon Monogram Empreinte Leather Wallet', '/Images/UploadProductImages/LV-Burgundy-Sarah-Maroon-Monogram-Empreinte-Leather-Wallet.jpg', 820),
                    (0, 1, 'AVAI', 12, 'LV Epi Malesherbes Hand Bag', '/Images/UploadProductImages/LV-Epi-Malesherbes-Hand-Bag.jpg', 290),
                    (0, 1, 'AVAI', 12, 'LV Limited Edition Christmas Animation 2021 Hollywood Mini Pochette', '/Images/UploadProductImages/LV-Limited-Edition-Christmas-Animation-2021-Hollywood-Mini-Pochette.jpg', 650),
                    (0, 1, 'AVAI', 12, 'LV Vernis Santa Monica Bag', '/Images/UploadProductImages/LV-Vernis-Santa-Monica-Bag.jpg', 180),

                    (0, 1, 'AVAI', 13, 'MIUMIU Crystal Long Wallet', '/Images/UploadProductImages/MIUMIU-Crystal-Long-Wallet.jpg', 310),

                    (0, 1, 'AVAI', 14, 'PRADA Comic Calf Leather Dual Bag', '/Images/UploadProductImages/PRADA-Comic-Calf-Leather-Dual-Bag.jpg', 320),
                    (0, 1, 'AVAI', 14, 'PRADA Nylon & Saffiano Leather Bag', '/Images/UploadProductImages/PRADA-Nylon-&-Saffiano-Leather-Bag.jpg', 210),
                    (0, 1, 'AVAI', 14, 'PRADA Saffiano Leather Wristlet Wallet', '/Images/UploadProductImages/PRADA-Saffiano-Leather-Wristlet-Wallet.jpg', 710)
                ");
        }

        public override void Down()
        {
            Sql("DELETE FROM Products");
        }
    }
}
