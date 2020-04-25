namespace CARMASTERY.UI.Migrations
{
    using CARMASTERY.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarEntity context)
        {
            context.States.AddOrUpdate(
               x => x.StateId,
               new CARMASTERY.Models.DataModels.State { StateId = 1, StateAB = "MN" },
               new CARMASTERY.Models.DataModels.State { StateId = 2, StateAB = "WI" },
               new CARMASTERY.Models.DataModels.State { StateId = 3, StateAB = "IL" },
               new CARMASTERY.Models.DataModels.State { StateId = 4, StateAB = "WY" },
               new CARMASTERY.Models.DataModels.State { StateId = 5, StateAB = "CA" }
               );
            context.SaveChanges();

            //Role
            context.Roless.AddOrUpdate(
                x => x.RoleId,
                new CARMASTERY.Models.DataModels.Role { RoleId = 1, RoleDescription = "Admin" },
                new CARMASTERY.Models.DataModels.Role { RoleId = 2, RoleDescription = "Sales" }
                );
            context.SaveChanges();

            //Users
            context.Userss.AddOrUpdate(
                x => x.UserId,
                new CARMASTERY.Models.DataModels.User { UserId = 1, FirstName = "Bob", LastName = "Vance", Email = "tertjwertewjtewth@gmail.com", Role = "Sales", Password = "abc", ConfirmPassword = "abc" },
                new CARMASTERY.Models.DataModels.User { UserId = 2, FirstName = "Nate", LastName = "Mader", Email = "ngntjrjhrdjhrjefhdjf@gmail.com", Role = "Sales", Password = "aaa", ConfirmPassword = "aaa" }
                );
            context.SaveChanges();

            //VehicleTypes new used
            context.VehicleTypes.AddOrUpdate(
                x => x.VehicleTypeId,
                new CARMASTERY.Models.DataModels.VehicleType { VehicleTypeId = 1, TypeDescription = "New" },//Mileage 0-1000
                new CARMASTERY.Models.DataModels.VehicleType { VehicleTypeId = 2, TypeDescription = "Used" }//Mileage 1000+
                );
            context.SaveChanges();

            //PurchaseTypes bank, dealer, cash
            context.PurchaseTypes.AddOrUpdate(
                x => x.PurchaseTypeId,
                new CARMASTERY.Models.DataModels.PurchaseType { PurchaseTypeId = 1, PurchaseTypeDescription = "Bank Finance" },
                new CARMASTERY.Models.DataModels.PurchaseType { PurchaseTypeId = 2, PurchaseTypeDescription = "Cash" },
                new CARMASTERY.Models.DataModels.PurchaseType { PurchaseTypeId = 3, PurchaseTypeDescription = "Dealer Finance" }
                );
            context.SaveChanges();

            //Makes
            context.Makes.AddOrUpdate(
                x => x.MakeId,
                new CARMASTERY.Models.DataModels.Make { MakeId = 1, MakeDescription = "Honda", DateCreated = DateTime.Now }, //UserId = 2},
                new CARMASTERY.Models.DataModels.Make { MakeId = 2, MakeDescription = "Ford", DateCreated = DateTime.Now }, //UserId = 2},
                new CARMASTERY.Models.DataModels.Make { MakeId = 3, MakeDescription = "Audi", DateCreated = DateTime.Now } //UserId = 2}
                );
            context.SaveChanges();

            //Models
            //Not sure if i need to index.......
            context.Models.AddOrUpdate(
                x => x.ModelId,
                new CARMASTERY.Models.DataModels.Model { ModelId = 1, ModelDescription = "Civic" },
                new CARMASTERY.Models.DataModels.Model { ModelId = 2, ModelDescription = "Pilot" },
                new CARMASTERY.Models.DataModels.Model { ModelId = 3, ModelDescription = "F-150"},
                new CARMASTERY.Models.DataModels.Model { ModelId = 4, ModelDescription = "Transit Van"},
                new CARMASTERY.Models.DataModels.Model { ModelId = 5, ModelDescription = "Focus"},
                new CARMASTERY.Models.DataModels.Model { ModelId = 6, ModelDescription = "A4"},
                new CARMASTERY.Models.DataModels.Model { ModelId = 7, ModelDescription = "S5"}
                );
            context.SaveChanges();

            //Transmission auto manual
            context.Transmissions.AddOrUpdate(
                x => x.TransmissionId,
                new CARMASTERY.Models.DataModels.Transmission { TransmissionId = 1, TransmissionType = "Automatic" },
                new CARMASTERY.Models.DataModels.Transmission { TransmissionId = 2, TransmissionType = "Manual" }
                );
            context.SaveChanges();

            //Interior Colors
            context.InteriorColors.AddOrUpdate(
                x => x.InteriorColorId,
                new CARMASTERY.Models.DataModels.InteriorColor { InteriorColorId = 1, InteriorColorDescription = "White" },
                new CARMASTERY.Models.DataModels.InteriorColor { InteriorColorId = 2, InteriorColorDescription = "Silver" },
                new CARMASTERY.Models.DataModels.InteriorColor { InteriorColorId = 3, InteriorColorDescription = "Black" },
                new CARMASTERY.Models.DataModels.InteriorColor { InteriorColorId = 4, InteriorColorDescription = "Light Brown" }
                );
            context.SaveChanges();

            //Exterior Colors
            context.ExteriorColors.AddOrUpdate(
                x => x.ExteriorColorId,
                new CARMASTERY.Models.DataModels.ExteriorColor { ExteriorColorId = 1, ExteriorColorDescription = "Dark Blue" },
                new CARMASTERY.Models.DataModels.ExteriorColor { ExteriorColorId = 2, ExteriorColorDescription = "Dark Green" },
                new CARMASTERY.Models.DataModels.ExteriorColor { ExteriorColorId = 3, ExteriorColorDescription = "Silver" },
                new CARMASTERY.Models.DataModels.ExteriorColor { ExteriorColorId = 4, ExteriorColorDescription = "Black" },
                new CARMASTERY.Models.DataModels.ExteriorColor { ExteriorColorId = 5, ExteriorColorDescription = "White" }
                );
            context.SaveChanges();

            //BodyStyles truck, car, suv, van
            context.BodyStyles.AddOrUpdate(
                x => x.BodyStyleId,
                new CARMASTERY.Models.DataModels.BodyStyle { BodyStyleId = 1, BodyStyleDescription = "Truck" },
                new CARMASTERY.Models.DataModels.BodyStyle { BodyStyleId = 2, BodyStyleDescription = "Car" },
                new CARMASTERY.Models.DataModels.BodyStyle { BodyStyleId = 3, BodyStyleDescription = "SUV" },
                new CARMASTERY.Models.DataModels.BodyStyle { BodyStyleId = 4, BodyStyleDescription = "Van" }
                );
            context.SaveChanges();

            //Specials
            context.Specials.AddOrUpdate(
                x => x.SpecialId,
                new CARMASTERY.Models.DataModels.Special { SpecialId = 1, SpecialTitle = "Zero Down", SpecialDescription = "Zero down-payment required for purchase." },
                new CARMASTERY.Models.DataModels.Special { SpecialId = 2, SpecialTitle = "2% Off", SpecialDescription = "Just kidding" }
                );
            context.SaveChanges();

            //Vehicles
            context.Vehicles.AddOrUpdate(
                x => x.VehicleId,
                new CARMASTERY.Models.DataModels.Vehicle
                {
                    VehicleId = 1,
                    VehicleDescription = "Brand New Honda Civic",
                    SalePrice = 25000M, //> than MSRP
                    MSRP = 20000M,
                    Year = 2019,
                    Vin = "SDJT67JHTYW7890OH",
                    Mileage = 120, //New under 1000
                    Featured = true,
                    SoldOut = false,
                    ImageFileName = "Vehicle1.png",
                    VehicleTypeId = 1, //New1
                    ModelId = 1, //Civic
                    TransmissionId = 2, //Manual
                    BodyStyleId = 2, //Car
                    ExteriorColorId = 1, //Dark Blue
                    InteriorColorId = 2 //Silver
                },
                new CARMASTERY.Models.DataModels.Vehicle
                {
                    VehicleId = 2,
                    VehicleDescription = "Brand New Ford F-150 Truck",
                    SalePrice = 60000M, //> than MSRP
                    MSRP = 58000M,
                    Year = 2019,
                    Vin = "HSKDTE3425H45HDTY",
                    Mileage = 10, //New under 1000
                    Featured = true,
                    SoldOut = false,
                    ImageFileName = "Vehicle2.png",
                    VehicleTypeId = 1, //New
                    ModelId = 3, //F-150
                    TransmissionId = 1, //Auto
                    BodyStyleId = 1, //truck
                    ExteriorColorId = 3, //black
                    InteriorColorId = 3 //black
                },
                new CARMASTERY.Models.DataModels.Vehicle
                {
                    VehicleId = 3,
                    VehicleDescription = "Used Audi A4",
                    SalePrice = 8000M, //> than MSRP
                    MSRP = 6000M,
                    Year = 2005,
                    Vin = "HK3456DFTYEJ3567K",
                    Mileage = 150000, //used over 1000
                    Featured = false,
                    SoldOut = false,
                    ImageFileName = "Vehicle3.png",
                    VehicleTypeId = 2, //used
                    ModelId = 6, //A4
                    TransmissionId = 2, //Manual
                    BodyStyleId = 2, //car
                    ExteriorColorId = 3, //black
                    InteriorColorId = 3 //black
                },
                new CARMASTERY.Models.DataModels.Vehicle
                {
                    VehicleId = 4,
                    VehicleDescription = "Used Ford Transit Van",
                    SalePrice = 35000M, //> than MSRP
                    MSRP = 30000M,
                    Year = 2010,
                    Vin = "JKSHTEHFYTEK12345",
                    Mileage = 40000, //used over 1000
                    Featured = false,
                    SoldOut = true,
                    ImageFileName = "Vehicle4.png",
                    VehicleTypeId = 2, //used
                    ModelId = 4, //transit
                    TransmissionId = 1, //auto
                    BodyStyleId = 4, //van
                    ExteriorColorId = 5, //white
                    InteriorColorId = 2 //silver
                },
                new CARMASTERY.Models.DataModels.Vehicle
                {
                    VehicleId = 5,
                    VehicleDescription = "New Honda Pilot",
                    SalePrice = 50000M, //> than MSRP
                    MSRP = 46000M,
                    Year = 2019,
                    Vin = "JDHETDY567349HJT3",
                    Mileage = 695, //used over 1000
                    Featured = true,
                    SoldOut = false,
                    ImageFileName = "Vehicle5.png",
                    VehicleTypeId = 1, //new
                    ModelId = 2, //pilot
                    TransmissionId = 1, //auto
                    BodyStyleId = 3, //suv
                    ExteriorColorId = 5, //white
                    InteriorColorId = 2 //silver
                }
                );
            context.SaveChanges();

            //Contact
            context.Contacts.AddOrUpdate(
               x => x.ContactId,
               new CARMASTERY.Models.DataModels.Contact { ContactId = 1, Name = "Bob Vance", Email = "VanceRefrigeration121@gmail.com", Phone = "612-345-2222", Message = "Crash er again. Looking for a new one.", VehicleId = 2 },
               new CARMASTERY.Models.DataModels.Contact { ContactId = 2, Name = "JimBob", Email = "SlimJim@gmail.com", Phone = "312-454-6666", Message = "Hey, could use a discount if ya got one. Just saying.", VehicleId = 1 }
               );
            context.SaveChanges();

            //Purchase
            context.Purchases.AddOrUpdate(
                x => x.PurchaseId,
                new CARMASTERY.Models.DataModels.Purchase
                {
                    PurchaseId = 1,
                    Name = "John Smith",
                    Phone = "111-111-2222",
                    Email = "johnnyS@gmail.com",
                    StreetAddress1 = "1111 Smith Road",
                    StreetAddress2 = "333 Snelling",
                    City = "Johnland",
                    ZipCode = 32334,
                    PurchasePrice = 50000M,
                    DatePurchased = DateTime.Now,
                    PurchaseTypeId = 1,
                    StateId = 5,
                    VehicleId = 5,
                    UserId = 1,
                    HasBeenPurchased = true,
                },
                new CARMASTERY.Models.DataModels.Purchase
                {
                    PurchaseId = 2,
                    Name = "Jane Doe",
                    Phone = "222-222-1111",
                    Email = "jani@gmail.com",
                    StreetAddress1 = "222 Pork Blvd",
                    StreetAddress2 = "",
                    City = "Janesville",
                    ZipCode = 43434,
                    PurchasePrice = 30000M,
                    DatePurchased = DateTime.Now,
                    PurchaseTypeId = 2,
                    StateId = 1,
                    VehicleId = 4,
                    UserId = 1,
                    HasBeenPurchased = true,
                }
                );
        }
    }
}
