namespace LuigiiLuxury.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateOrderStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO OrderStatus (Code, Name)
                VALUES 
                    ('processing', 'processing'),
                    ('fraud', 'suspected fraud'),
                    ('pending_payment', 'pending payment'),
                    ('payment_review', 'pending review'),
                    ('pending', 'pending'),
                    ('holded', 'on hold'),
                    ('STATE_OPEN', 'open'),
                    ('complete', 'complete'),
                    ('closed', 'closed'),
                    ('canceled', 'canceled'),
                    ('paypay_canceled_reversal', 'paypal canceled reversal'),
                    ('pending_paypal', 'pending paypal'),
                    ('paypal_reversed', 'paypal reversed')
                ");
        }

        public override void Down()
        {
            Sql("DELETE FROM OrderStatus");
        }
    }
}
