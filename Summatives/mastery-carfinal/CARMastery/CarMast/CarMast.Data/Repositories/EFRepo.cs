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
    public class EFRepo : ICarMasteryRepo
    {
        private CarEntity context;

        public EFRepo()
        {
            context = new CarEntity();
        }

        public void AddUser(User userToCreate)
        {
            var userList = context.Userss;
            if (userList.Any())
            {
                userToCreate.UserId = userList.Max(x => x.UserId) + 1;

            }
            else
            {
                userToCreate.UserId = 1;
            }
            context.Userss.Add(userToCreate);
            context.SaveChanges();
        }

        public void CreateContact(Contact newContact)
        {
            throw new NotImplementedException();
        }

        public void CreateSpecial(Special specialToCreate)
        {
            throw new NotImplementedException();
        }

        public void CreateVehicle(Vehicle vehicleToCreate)
        {
            var vehicleList = context.Vehicles;

            if (vehicleList.Any())
            {
                vehicleToCreate.VehicleId = vehicleList.Max(x => x.VehicleId) + 1;

            }
            else
            {
                vehicleToCreate.VehicleId = 1;
            }
            context.Vehicles.Add(vehicleToCreate);
            context.SaveChanges();
        }

        public void DeleteSpecial(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<BodyStyle> GetAllBodyStyles()
        {
            var body = (from x in context.BodyStyles
                             select x).ToList();
            return body;
        }

        public List<Contact> GetAllContacts()
        {
            var contacts = (from x in context.Contacts
                             select x).ToList();
            return contacts;
        }

        public List<ExteriorColor> GetAllExteriorColors()
        {
            var exterior = (from x in context.ExteriorColors
                             select x).ToList();
            return exterior;
        }

        public List<InteriorColor> GetAllInteriorColors()
        {
            var interior = (from x in context.InteriorColors
                             select x).ToList();
            return interior;
        }

        public List<Make> GetAllMakes()
        {
            var makes = (from x in context.Makes
                         select x).ToList();
            return makes;
        }

        public List<Model> GetAllModels()
        {
            var models = (from x in context.Models
                          select x).ToList();
            return models;
        }

        public List<Purchase> GetAllPurchases()
        {
            var purchases = (from x in context.Purchases
                             select x).ToList();
            return purchases;
        }

        public List<Role> GetAllRoles()
        {
            var roles = (from x in context.Roless
                         select x).ToList();
            return roles;
        }

        public List<Special> GetAllSpecials()
        {
            var specials = (from x in context.Specials
                            select x).ToList();
            return specials;
        }

        public List<Transmission> GetAllTransmissions()
        {
            var trans = (from x in context.Transmissions
                         select x).ToList();
            return trans;
        }

        public List<User> GetAllUsers()
        {
            var users = (from x in context.Userss
                         select x).ToList();
            return users;
        }

        public List<Vehicle> GetAllVehicles()
        {
            var vehicles = (from x in context.Vehicles
                            select x).ToList();
            return vehicles;
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            var types = (from x in context.VehicleTypes
                         select x).ToList();
            return types;
        }

        public Special GetById(int id)
        {
            var special = (from x in context.Specials
                           where x.SpecialId == id
                           select x).FirstOrDefault();
            return special;
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            var featured = (from x in context.Vehicles
                            where x.Featured == true
                            select x).ToList();
            return featured;
        }

        public List<Vehicle> GetNewVehicles()
        {
            var vehicles = (from x in context.Vehicles
                            where x.VehicleType.TypeDescription == "New"
                            select x).OrderByDescending(x => x.MSRP).ToList();
            return vehicles;
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            var ptypes = (from x in context.PurchaseTypes
                          select x).ToList();
            return ptypes;
        }

        public Vehicle GetSingleVehicle(int id)
        {
            var vehicle = (from v in context.Vehicles
                           where v.VehicleId == id
                           select v).FirstOrDefault();
            return vehicle;
        }

        public List<Vehicle> GetUsedVehicles()
        {
            var vehicles = (from x in context.Vehicles
                            where x.VehicleType.TypeDescription == "Used"
                            select x).OrderByDescending(x => x.MSRP).ToList();
            return vehicles;
        }

        public User GetUserById(int id)
        {
            var user = (from x in context.Userss
                        where x.UserId == id
                        select x).FirstOrDefault();
            return user;
        }

        public List<Vehicle> GetVehiclesForSale()
        {
            var vForSale = (from x in context.Vehicles
                            where x.SoldOut == false
                            select x).ToList();
            return vForSale;
        }

        public List<Vehicle> SearchNewVehicles(SearchViewModel vehicle)
        {
            var query = context.Vehicles.Where(x => x.VehicleType.TypeDescription.Equals("New") && x.SoldOut.Equals(false));

            if (string.IsNullOrEmpty(vehicle.Input) && !vehicle.MinPrice.HasValue && !vehicle.MaxPrice.HasValue && !vehicle.MinYear.HasValue && !vehicle.MaxYear.HasValue)
            {
                query = query.OrderByDescending(x => x.MSRP).Take(20);
            }
            if (!string.IsNullOrEmpty(vehicle.Input))
            {
                query = query.Where(x => x.Model.Make.MakeDescription.ToString().Contains(vehicle.Input) || x.Model.ModelDescription.ToString().Contains(vehicle.Input) || x.Year.ToString().Contains(vehicle.Input));
            }
            if (vehicle.MinPrice.HasValue)
            {
                query = query.Where(x => x.SalePrice <= vehicle.MinPrice);
            }
            if (vehicle.MaxPrice.HasValue)
            {
                query = query.Where(x => x.MSRP <= vehicle.MaxPrice);
            }
            if (vehicle.MinYear.HasValue)
            {
                query = query.Where(x => x.Year >= vehicle.MinYear);
            }
            if (vehicle.MaxYear.HasValue)
            {
                query = query.Where(x => x.Year <= vehicle.MaxYear);
            }
            return query.ToList();
        }

        public List<Vehicle> SearchUsedVehicles(SearchViewModel vehicle)
        {
            var query = context.Vehicles.Where(x => x.VehicleType.TypeDescription.Equals("Used") && x.SoldOut.Equals(false));

            if (string.IsNullOrEmpty(vehicle.Input) && !vehicle.MinPrice.HasValue && !vehicle.MaxPrice.HasValue && !vehicle.MinYear.HasValue && !vehicle.MaxYear.HasValue)
            {
                query = query.OrderByDescending(x => x.MSRP).Take(20);
            }
            if (!string.IsNullOrEmpty(vehicle.Input))
            {
                query = query.Where(x => x.Model.Make.MakeDescription.ToString().Contains(vehicle.Input) || x.Model.ModelDescription.ToString().Contains(vehicle.Input) || x.Year.ToString().Contains(vehicle.Input));
            }
            if (vehicle.MinPrice.HasValue)
            {
                query = query.Where(x => x.SalePrice <= vehicle.MinPrice);
            }
            if (vehicle.MaxPrice.HasValue)
            {
                query = query.Where(x => x.MSRP <= vehicle.MaxPrice);
            }
            if (vehicle.MinYear.HasValue)
            {
                query = query.Where(x => x.Year >= vehicle.MinYear);
            }
            if (vehicle.MaxYear.HasValue)
            {
                query = query.Where(x => x.Year <= vehicle.MaxYear);
            }
            return query.ToList();
        }

        public List<State> GetAllStates()
        {
            var statesList = (from x in context.States
                              select x).ToList();
            return statesList;
        }

        public void CreateMake(Make makeToCreate)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> SearchSalesVehicles(SearchViewModel vehicle)
        {
            var query = context.Vehicles.Where(x => x.SoldOut.Equals(false) && x.SoldOut.Equals(false));

            if (string.IsNullOrEmpty(vehicle.Input) && !vehicle.MinPrice.HasValue && !vehicle.MaxPrice.HasValue && !vehicle.MinYear.HasValue && !vehicle.MaxYear.HasValue)
            {
                query = query.OrderByDescending(x => x.MSRP).Take(20);
            }
            if (!string.IsNullOrEmpty(vehicle.Input))
            {
                query = query.Where(x => x.Model.Make.MakeDescription.ToString().Contains(vehicle.Input) || x.Model.ModelDescription.ToString().Contains(vehicle.Input) || x.Year.ToString().Contains(vehicle.Input));
            }
            if (vehicle.MinPrice.HasValue)
            {
                query = query.Where(x => x.SalePrice <= vehicle.MinPrice);
            }
            if (vehicle.MaxPrice.HasValue)
            {
                query = query.Where(x => x.MSRP <= vehicle.MaxPrice);
            }
            if (vehicle.MinYear.HasValue)
            {
                query = query.Where(x => x.Year >= vehicle.MinYear);
            }
            if (vehicle.MaxYear.HasValue)
            {
                query = query.Where(x => x.Year <= vehicle.MaxYear);
            }
            return query.ToList();
        }

        //Nate likes
        public void AddPurchase(Purchase purchaseToAdd)
        {
            var purchaseList = context.Purchases;

            if (purchaseList.Any())
            {
                purchaseToAdd.PurchaseId = purchaseList.Max(x => x.PurchaseId) + 1;

            }
            else
            {
                purchaseToAdd.PurchaseId = 1;
            }
            purchaseToAdd.DatePurchased = DateTime.Now;
            context.Purchases.Add(purchaseToAdd);
            context.SaveChanges();
        }

        //Nate likes
        public void CreateModel(Model modelToCreate)
        {
            var modelsList = context.Models;

            if (modelsList.Any())
            {
                modelToCreate.ModelId = modelsList.Max(x => x.ModelId) + 1;

            }
            else
            {
                modelToCreate.ModelId = 1;
            }
            modelToCreate.DateAdded = DateTime.Now;
            context.Models.Add(modelToCreate);
            context.SaveChanges();
        }

        public Make GetMakeById(int id)
        {
            var make = (from x in context.Makes
                        where x.MakeId == id
                        select x).FirstOrDefault();
            return make;
        }
    }
}
