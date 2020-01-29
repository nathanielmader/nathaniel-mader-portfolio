using CarMast.Data.Interfaces;
using CarMast.Models.DataModels;
using CarMast.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Data.Repositories
{
    public class MockRepo : ICarMasteryRepo
    {
        private static List<Role> _roles;
        private static List<User> _users;//
        private static List<Special> _specials;//
        private static List<Vehicle> _vehicles;//
        private static List<Model> _models;//
        private static List<Make> _makes;//
        private static List<Transmission> _transmissions;//
        private static List<BodyStyle> _bodyStyles;//
        private static List<ExteriorColor> _exteriorColors;//
        private static List<InteriorColor> _interiorColors;//
        private static List<PurchaseType> _purchaseTypes;//
        private static List<VehicleType> _vehicleTypes;//
        private static List<Contact> _contacts;//
        private static List<State> _states;
        private static List<Purchase> _purchases;


        static MockRepo()
        {
            _states = new List<State>()
            {
                new State{ StateId = 1, StateAB = "MN"},
                new State{ StateId = 2, StateAB = "WI"},
                new State{ StateId = 3, StateAB = "IL"},
                new State{ StateId = 4, StateAB = "WY"},
                new State{ StateId = 5, StateAB = "CA"}
            };
            _roles = new List<Role>()
            {
                new Role { RoleId = 1, RoleDescription = "Admin" },
                new Role { RoleId = 2, RoleDescription = "Sales" }
            };
            _users = new List<User>()
            {
                new User { UserId = 1, FirstName = "Bob", LastName = "Vance" , Email = "tertjwertewjtewth@gmail.com", Role = "Sales", Password = "abc", ConfirmPassword = "abc"},
                new User { UserId = 2, FirstName = "Nate", LastName = "Mader", Email = "ngntjrjhrdjhrjefhdjf@gmail.com", Role = "Sales", Password = "aaa", ConfirmPassword = "aaa" }
            };
            _vehicleTypes = new List<VehicleType>()
            {
                new VehicleType { VehicleTypeId = 1, TypeDescription = "New" },//Mileage 0-1000
                new VehicleType { VehicleTypeId = 2, TypeDescription = "Used" }//Mileage 1000+
            };
            _purchaseTypes = new List<PurchaseType>()
            {
                new PurchaseType { PurchaseTypeId = 1, PurchaseTypeDescription = "Bank Finance" },
                new PurchaseType { PurchaseTypeId = 2, PurchaseTypeDescription = "Cash" },
                new PurchaseType { PurchaseTypeId = 3, PurchaseTypeDescription = "Dealer Finance" }
            };
            _makes = new List<Make>()
            {
                new Make { MakeId = 1, MakeDescription = "Honda", DateCreated = DateTime.Now },//UserId = 2, User = _users[1] },
                new Make { MakeId = 2, MakeDescription = "Ford", DateCreated = DateTime.Now }, //UserId = 2, User = _users[1]},
                new Make { MakeId = 3, MakeDescription = "Audi", DateCreated = DateTime.Now } //UserId = 2, User = _users[1]}
            };
            _models = new List<Model>()
            {
                new Model { ModelId = 1, ModelDescription = "Civic", DateAdded = DateTime.Now, MakeId = 1, Make = _makes[0] },
                new Model { ModelId = 2, ModelDescription = "Pilot", DateAdded = DateTime.Now, MakeId = 1, Make = _makes[0] },
                new Model { ModelId = 3, ModelDescription = "F-150", DateAdded = DateTime.Now, MakeId = 2, Make = _makes[1] },
                new Model { ModelId = 4, ModelDescription = "Transit Van", DateAdded = DateTime.Now, MakeId = 2, Make = _makes[1]},
                new Model { ModelId = 5, ModelDescription = "Focus", DateAdded = DateTime.Now, MakeId = 2, Make = _makes[1] },
                new Model { ModelId = 6, ModelDescription = "A4", DateAdded = DateTime.Now, MakeId = 3, Make = _makes[2] },
                new Model { ModelId = 7, ModelDescription = "S5", DateAdded = DateTime.Now, MakeId = 3, Make = _makes[2] }
            };
            _transmissions = new List<Transmission>()
            {
                new Transmission { TransmissionId = 1, TransmissionType = "Automatic"},
                new Transmission { TransmissionId = 2, TransmissionType= "Manual"}
            };

            _interiorColors = new List<InteriorColor>()
            {
                new InteriorColor { InteriorColorId = 1, InteriorColorDescription = "White" },
                new InteriorColor { InteriorColorId = 2, InteriorColorDescription = "Silver" },
                new InteriorColor { InteriorColorId = 3, InteriorColorDescription = "Black" },
                new InteriorColor { InteriorColorId = 4, InteriorColorDescription = "Light Brown" }
            };
            _exteriorColors = new List<ExteriorColor>()
            {
                new ExteriorColor { ExteriorColorId = 1, ExteriorColorDescription = "Dark Blue" },
                new ExteriorColor { ExteriorColorId = 2, ExteriorColorDescription = "Dark Green" },
                new ExteriorColor { ExteriorColorId = 3, ExteriorColorDescription = "Silver" },
                new ExteriorColor { ExteriorColorId = 4, ExteriorColorDescription = "Black" },
                new ExteriorColor { ExteriorColorId = 5, ExteriorColorDescription = "White" }
            };
            _bodyStyles = new List<BodyStyle>()
            {
                new BodyStyle { BodyStyleId = 1, BodyStyleDescription = "Truck"},
                new BodyStyle { BodyStyleId = 2, BodyStyleDescription = "Car" },
                new BodyStyle { BodyStyleId = 3, BodyStyleDescription = "SUV" },
                new BodyStyle { BodyStyleId = 4, BodyStyleDescription = "Van" }
            };
            _specials = new List<Special>()
            {
                new Special { SpecialId = 1, SpecialTitle = "tttty", SpecialDescription = "dfdfdfdsfsfdsfdsfdsfdsfsdfdsfdsfsdfs"},
                new Special { SpecialId = 2, SpecialTitle = "hoho", SpecialDescription = "this pretty"},
            };

            _vehicles = new List<Vehicle>()
            {
                new Vehicle
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
                    VehicleType = _vehicleTypes[0],
                    ModelId = 1, //Civic
                    Model = _models[0],
                    TransmissionId = 2, //Manual
                    Transmission = _transmissions[1],
                    BodyStyleId = 2, //Car
                    BodyStlye = _bodyStyles[1],
                    ExteriorColorId = 1, //Dark Blue
                    ExteriorColor = _exteriorColors[0],
                    InteriorColorId = 2, //Silver
                    InteriorColor = _interiorColors[1]

                },
                new Vehicle
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
                    VehicleType = _vehicleTypes[0],
                    ModelId = 3, //F-150
                    Model = _models[2],
                    TransmissionId = 1, //Auto
                    Transmission = _transmissions[0],
                    BodyStyleId = 1, //truck
                    BodyStlye = _bodyStyles[0],
                    ExteriorColorId = 3, //black
                    ExteriorColor = _exteriorColors[2],
                    InteriorColorId = 3, //black
                    InteriorColor = _interiorColors[2]
                },
                new Vehicle
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
                    VehicleType = _vehicleTypes[1],
                    ModelId = 6, //A4
                    Model = _models[5],
                    TransmissionId = 2, //Manual
                    Transmission = _transmissions[1],
                    BodyStyleId = 2, //car
                    BodyStlye = _bodyStyles[1],
                    ExteriorColorId = 3, //black
                    ExteriorColor = _exteriorColors[2],
                    InteriorColorId = 3, //black
                    InteriorColor = _interiorColors[2]
                },
                new Vehicle
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
                    VehicleType = _vehicleTypes[1],
                    ModelId = 4, //transit
                    Model = _models[3],
                    TransmissionId = 1, //auto
                    Transmission = _transmissions[0],
                    BodyStyleId = 4, //van
                    BodyStlye = _bodyStyles[3],
                    ExteriorColorId = 5, //white
                    ExteriorColor = _exteriorColors[4],
                    InteriorColorId = 2, //silver
                    InteriorColor = _interiorColors[1]
                },
                new Vehicle
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
                    VehicleType = _vehicleTypes[0],
                    ModelId = 2, //pilot
                    Model = _models[1],
                    TransmissionId = 1, //auto
                    Transmission = _transmissions[0],
                    BodyStyleId = 3, //suv
                    BodyStlye = _bodyStyles[2],
                    ExteriorColorId = 5, //white
                    ExteriorColor = _exteriorColors[4],
                    InteriorColorId = 2, //silver
                    InteriorColor = _interiorColors[1],

                }
            };
            _contacts = new List<Contact>()
            {
                new Contact {ContactId = 1, Name = "Bob Vance", Email = "VanceRefrigeration121@gmail.com", Phone = "612-345-2222", Message = "Crash er again. Looking for a new one.", VehicleId = 2, Vehicle = _vehicles[1] },
                new Contact {ContactId = 2, Name = "JimBob", Email = "SlimJim@gmail.com", Phone = "312-454-6666", Message = "Hey, could use a discount if ya got one. Just saying.", VehicleId = 1, Vehicle = _vehicles[0] },
            };
            _purchases = new List<Purchase>()
            {
                new Purchase
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
                    PurchaseType = _purchaseTypes[0],
                    StateId = 5,
                    State = _states[4],
                    VehicleId = 5,
                    Vehicle = _vehicles[4],
                    UserId = 1,
                    User = _users[0]
                },
                new Purchase
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
                    PurchaseType = _purchaseTypes[1],
                    StateId = 1,
                    State = _states[0],
                    VehicleId = 4,
                    Vehicle = _vehicles[3],
                    UserId = 1,
                    User = _users[0]
                }
            };
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void CreateContact(Contact newContact)
        {
            if (_contacts.Any())
            {
                newContact.ContactId = _contacts.Max(x => x.ContactId) + 1;

            }
            else
            {
                newContact.ContactId = 1;
            }

            _contacts.Add(newContact);
        }

        public void CreateSpecial(Special specialToCreate)
        {
            _specials.Add(specialToCreate);
        }

        public void CreateVehicle(Vehicle vehicleToCreate)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = vehicleToCreate;
            vehicleToCreate.VehicleId = _vehicles.Max(v => v.VehicleId) + 1;
            vehicle.VehicleId = vehicleToCreate.VehicleId;
            vehicle.Model = _models.FirstOrDefault(m => m.ModelId == vehicleToCreate.Model.ModelId);
            vehicle.BodyStlye = _bodyStyles.FirstOrDefault(b => b.BodyStyleId == vehicleToCreate.BodyStlye.BodyStyleId);
            vehicle.ExteriorColor = _exteriorColors.FirstOrDefault(c => c.ExteriorColorId == vehicleToCreate.ExteriorColor.ExteriorColorId);
            vehicle.InteriorColor = _interiorColors.FirstOrDefault(c => c.InteriorColorId == vehicleToCreate.InteriorColor.InteriorColorId);
            vehicle.Transmission = _transmissions.FirstOrDefault(t => t.TransmissionId == vehicleToCreate.Transmission.TransmissionId);
            vehicle.VehicleType = _vehicleTypes.FirstOrDefault(t => t.VehicleTypeId == vehicleToCreate.VehicleTypeId);
            vehicle.ImageFileName = vehicleToCreate.ImageFileName;
            vehicle.SoldOut = false;
            _vehicles.Add(vehicle);
        }

        public void DeleteSpecial(int id)
        {
            _specials.RemoveAll(x => x.SpecialId == id);
        }

        public void DeleteVehicle(int id)
        {
            _vehicles.RemoveAll(x => x.VehicleId == id);
        }

        public void EditUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<BodyStyle> GetAllBodyStyles()
        {
            return _bodyStyles;
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public List<ExteriorColor> GetAllExteriorColors()
        {
            return _exteriorColors;
        }

        public List<InteriorColor> GetAllInteriorColors()
        {
            return _interiorColors;
        }

        public List<Make> GetAllMakes()
        {
            return _makes;
        }

        public List<Model> GetAllModels()
        {
            return _models;
        }

        public List<Purchase> GetAllPurchases()
        {
            return _purchases;
        }

        public List<Role> GetAllRoles()
        {
            return _roles;
        }

        public List<Special> GetAllSpecials()
        {
            return _specials;
        }

        public List<Transmission> GetAllTransmissions()
        {
            return _transmissions;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            return _vehicleTypes;
        }

        public Special GetById(int id)
        {
            return _specials.FirstOrDefault(x => x.SpecialId == id);
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return _vehicles.Where(x => x.Featured == true && x.SoldOut == false).ToList();
        }

        public List<Vehicle> GetNewVehicles()
        {
            return _vehicles.Where(x => x.VehicleTypeId == 1).ToList();
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            return _purchaseTypes;
        }

        public Vehicle GetSingleVehicle(int id)
        {
            return _vehicles.FirstOrDefault(x => x.VehicleId == id);
        }

        public List<Vehicle> GetUsedVehicles()
        {
            return _vehicles.Where(x => x.VehicleTypeId == 2).ToList();
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(x => x.UserId == id);
        }

        public List<Vehicle> GetVehiclesForSale()
        {
            return _vehicles.Where(x => x.SoldOut == false).ToList();
        }

        public List<Vehicle> SearchNewVehicles(SearchViewModel model)
        {
            //Where type description = new, grab all vehicles
            var v = _vehicles.Where(x => x.VehicleType.TypeDescription.Equals("New"));

            //Empty search
            if (string.IsNullOrEmpty(model.Input) && !model.MinPrice.HasValue && !model.MaxPrice.HasValue && !model.MinYear.HasValue && !model.MaxYear.HasValue)
            {
                //first 20 by msrp
                v = v.OrderByDescending(x => x.MSRP).Take(20);
            }
            if (!string.IsNullOrEmpty(model.Input))
            {
                v = v.Where(x => x.Model.Make.MakeDescription.ToString().Contains(model.Input) || x.Model.ModelDescription.ToString().Contains(model.Input) || x.Year.ToString().Contains(model.Input));
            }
            if (model.MinPrice.HasValue)
            {
                v = v.Where(x => x.MSRP >= model.MinPrice);
            }
            if (model.MaxPrice.HasValue)
            {
                v = v.Where(x => x.MSRP <= model.MaxPrice);
            }
            if (model.MinYear.HasValue)
            {
                v = v.Where(x => x.Year >= model.MinYear);
            }
            if (model.MaxYear.HasValue)
            {
                v = v.Where(x => x.Year <= model.MaxYear);
            }

            return v.ToList();
        }

        //Needs to be dynamic want to search with each entered value, if no value, return top 20 used vehicles
        public List<Vehicle> SearchUsedVehicles(SearchViewModel model)
        {
            var v = _vehicles.Where(x => x.VehicleType.TypeDescription.Equals("Used"));

            //Empty search
            if (string.IsNullOrEmpty(model.Input) && !model.MinPrice.HasValue && !model.MaxPrice.HasValue && !model.MinYear.HasValue && !model.MaxYear.HasValue)
            {
                //first 20 by msrp
                v = v.OrderByDescending(x => x.MSRP).Take(20);
            }
            if (!string.IsNullOrEmpty(model.Input))
            {
                v = v.Where(x => x.Model.Make.MakeDescription.ToString().Contains(model.Input) || x.Model.ModelDescription.ToString().Contains(model.Input) || x.Year.ToString().Contains(model.Input));
            }
            if (model.MinPrice.HasValue)
            {
                v = v.Where(x => x.MSRP >= model.MinPrice);
            }
            if (model.MaxPrice.HasValue)
            {
                v = v.Where(x => x.MSRP <= model.MaxPrice);
            }
            if (model.MinYear.HasValue)
            {
                v = v.Where(x => x.Year >= model.MinYear);
            }
            if (model.MaxYear.HasValue)
            {
                v = v.Where(x => x.Year <= model.MaxYear);
            }

            return v.ToList();
        }

        public List<State> GetAllStates()
        {
            return _states;
        }

        public void CreateMake(Make makeToCreate)
        {
            makeToCreate.DateCreated = DateTime.Now;
            _makes.Add(makeToCreate);
        }

        public List<Vehicle> SearchSalesVehicles(SearchViewModel vehicle)
        {
            throw new NotImplementedException();
        }

        public void AddPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public void CreateModel(Model modelToCreate)
        {
            throw new NotImplementedException();
        }

        public Make GetMakeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
