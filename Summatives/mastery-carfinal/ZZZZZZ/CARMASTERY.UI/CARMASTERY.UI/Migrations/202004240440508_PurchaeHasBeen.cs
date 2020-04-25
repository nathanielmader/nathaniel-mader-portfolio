namespace CARMASTERY.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaeHasBeen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "HasBeenPurchased", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "HasBeenPurchased");
        }
    }
}
