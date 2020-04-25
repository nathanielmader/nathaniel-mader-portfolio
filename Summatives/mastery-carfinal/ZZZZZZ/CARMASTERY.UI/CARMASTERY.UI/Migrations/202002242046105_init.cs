namespace CARMASTERY.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        BodyStyleId = c.Int(nullable: false, identity: true),
                        BodyStyleDescription = c.String(),
                    })
                .PrimaryKey(t => t.BodyStyleId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(nullable: false),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleDescription = c.String(),
                        VehicleTypeId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        TransmissionId = c.Int(nullable: false),
                        BodyStyleId = c.Int(nullable: false),
                        ExteriorColorId = c.Int(nullable: false),
                        InteriorColorId = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Year = c.Int(nullable: false),
                        Vin = c.String(),
                        Mileage = c.Int(nullable: false),
                        Featured = c.Boolean(nullable: false),
                        SoldOut = c.Boolean(nullable: false),
                        ImageFileName = c.String(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.BodyStyles", t => t.BodyStyleId, cascadeDelete: true)
                .ForeignKey("dbo.ExteriorColors", t => t.ExteriorColorId, cascadeDelete: true)
                .ForeignKey("dbo.InteriorColors", t => t.InteriorColorId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.ModelId)
                .Index(t => t.TransmissionId)
                .Index(t => t.BodyStyleId)
                .Index(t => t.ExteriorColorId)
                .Index(t => t.InteriorColorId);
            
            CreateTable(
                "dbo.ExteriorColors",
                c => new
                    {
                        ExteriorColorId = c.Int(nullable: false, identity: true),
                        ExteriorColorDescription = c.String(),
                    })
                .PrimaryKey(t => t.ExteriorColorId);
            
            CreateTable(
                "dbo.InteriorColors",
                c => new
                    {
                        InteriorColorId = c.Int(nullable: false, identity: true),
                        InteriorColorDescription = c.String(),
                    })
                .PrimaryKey(t => t.InteriorColorId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelDescription = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Makes", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeId = c.Int(nullable: false, identity: true),
                        MakeDescription = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MakeId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false, identity: true),
                        TransmissionType = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        TypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        StreetAddress1 = c.String(),
                        StreetAddress2 = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatePurchased = c.DateTime(nullable: false),
                        PurchaseTypeId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.StateId)
                .Index(t => t.VehicleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        PurchaseTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateAB = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleDescription = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false, identity: true),
                        SpecialTitle = c.String(nullable: false),
                        SpecialDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchases", "StateId", "dbo.States");
            DropForeignKey("dbo.Purchases", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Contacts", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Vehicles", "InteriorColorId", "dbo.InteriorColors");
            DropForeignKey("dbo.Vehicles", "ExteriorColorId", "dbo.ExteriorColors");
            DropForeignKey("dbo.Vehicles", "BodyStyleId", "dbo.BodyStyles");
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Purchases", new[] { "VehicleId" });
            DropIndex("dbo.Purchases", new[] { "StateId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropIndex("dbo.Vehicles", new[] { "InteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "ExteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "BodyStyleId" });
            DropIndex("dbo.Vehicles", new[] { "TransmissionId" });
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.Contacts", new[] { "VehicleId" });
            DropTable("dbo.Specials");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.States");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Purchases");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Makes");
            DropTable("dbo.Models");
            DropTable("dbo.InteriorColors");
            DropTable("dbo.ExteriorColors");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Contacts");
            DropTable("dbo.BodyStyles");
        }
    }
}
