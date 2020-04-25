namespace CARMASTERY.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelDatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "DateModified");
        }
    }
}
