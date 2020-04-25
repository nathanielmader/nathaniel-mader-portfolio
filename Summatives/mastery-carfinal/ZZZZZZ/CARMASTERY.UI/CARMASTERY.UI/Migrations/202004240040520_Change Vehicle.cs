namespace CARMASTERY.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "DateModified");
        }
    }
}
