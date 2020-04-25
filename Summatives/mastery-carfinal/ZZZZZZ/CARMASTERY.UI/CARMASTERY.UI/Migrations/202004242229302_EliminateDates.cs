namespace CARMASTERY.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminateDates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "DateModified");
            DropColumn("dbo.Models", "DateAdded");
            DropColumn("dbo.Models", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "DateModified", c => c.DateTime());
            AddColumn("dbo.Models", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicles", "DateModified", c => c.DateTime());
        }
    }
}
