using CARMASTERY.Data.Interface;
using CARMASTERY.Models.DataModels;
using CARMASTERY.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Data.Repos
{
    public class EFRepo : ICarMasteryRepo
    {
        private CarEntity context;

        public EFRepo()
        {
            context = new CarEntity();
        }

        public void AddPurchase(Purchase purchase)
        {
            context.Purchases.Add(purchase);
            context.SaveChanges();
        }

        public void AddUser(User user)
        {
            context.Userss.Add(user);
            context.SaveChanges();
        }

        public void CreateContact(Contact newContact)
        {
            Contact c = new Contact();
            c.Name = newContact.Name;
            c.Email = newContact.Email;
            c.Phone = newContact.Phone;
            c.Message = newContact.Message;
            context.Contacts.Add(c);
            context.SaveChanges();
        }

        public void CreateMake(Make makeToCreate)
        {
            makeToCreate.DateCreated = DateTime.Now;
            context.Makes.Add(makeToCreate);
            context.SaveChanges();
        }

        public void CreateModel(Model m)
        {
            //Model m = new Model();
            //m.Make.MakeId = modelToCreate.Make.MakeId;
            //m.ModelDescription = modelToCreate.ModelDescription;
            //m.DateAdded = modelToCreate.DateAdded;

            context.Models.Add(m);
            context.SaveChanges();
        }

        public void CreateSpecial(Special special)
        {
            context.Specials.Add(special);
            context.SaveChanges();
        }

        public void CreateVehicle(Vehicle vehicleToCreate)
        {
            context.Vehicles.Add(vehicleToCreate);
            context.SaveChanges();
        }

        public void DeleteSpecial(int id)
        {
            var specialToDelete = context.Specials.SingleOrDefault(x => x.SpecialId == id);
            context.Specials.Remove(specialToDelete);
            context.SaveChanges();
        }

        public void DeleteVehicle(int id)
        {
            var v = context.Vehicles.SingleOrDefault(x => x.VehicleId == id);
            context.Vehicles.Remove(v);
            context.SaveChanges();
        }

        public void EditUser(User userToEdit)
        {
            var user = context.Userss.FirstOrDefault(x => x.UserId == userToEdit.UserId);
            user.FirstName = userToEdit.FirstName;
            user.LastName = userToEdit.LastName;
            user.Email = userToEdit.Email;
            user.Password = userToEdit.Password;
            user.ConfirmPassword = userToEdit.ConfirmPassword;
            context.SaveChanges();

            //throw new NotImplementedException();

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

        public List<Vehicle> GetAllPurchasedVehicles()
        {
            var vehicles = (from x in context.Vehicles
                            where x.SoldOut == true
                            select x).ToList();
            return vehicles;

        }

        public List<Purchase> GetAllPurchases()
        {
            var purchases = (from x in context.Purchases
                             where x.HasBeenPurchased == true
                             select x).ToList();
            return purchases;
        }

        public List<Purchase> GetAllPurchasesBySingleUser(int id)
        {
            //var purchases = (from x in context.Purchases
            //                 where (x.UserId == id)
            //                 select x).ToList();
            //return purchases;
            throw new NotImplementedException();

        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            var ptypes = (from x in context.PurchaseTypes
                          select x).ToList();
            return ptypes;
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

        public List<State> GetAllStates()
        {
            var statesList = (from x in context.States
                              select x).ToList();
            return statesList;
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

        public BodyStyle GetBodyStyleById(int id)
        {
            var body = (from x in context.BodyStyles
                        where x.BodyStyleId == id
                        select x).FirstOrDefault();
            return body;
        }

        public Special GetById(int id)
        {
            var special = (from x in context.Specials
                           where x.SpecialId == id
                           select x).FirstOrDefault();
            return special;
        }

        public ExteriorColor GetExteriorColorById(int id)
        {
            var color = (from x in context.ExteriorColors
                         where x.ExteriorColorId == id
                         select x).FirstOrDefault();
            return color;
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            var featured = (from x in context.Vehicles
                            where x.Featured == true
                            select x).ToList();
            return featured;
        }

        public InteriorColor GetInteriorColorById(int id)
        {
            var color = (from x in context.InteriorColors
                         where x.InteriorColorId == id
                         select x).FirstOrDefault();
            return color;
        }

        public Make GetMakeById(int id)
        {
            var make = (from x in context.Makes
                        where x.MakeId == id
                        select x).FirstOrDefault();
            return make;

        }

        public Model GetModelById(int id)
        {
            var model = (from x in context.Models
                         where x.ModelId == id
                         select x).FirstOrDefault();
            return model;
        }

        public List<Model> GetModelByMakeId(int makeId)
        {
            var models = (from x in context.Models
                          where x.Make.MakeId == makeId
                          select x).ToList();
            return models;
        }

        public List<Vehicle> GetNewVehicles()
        {
            var vehicles = (from x in context.Vehicles
                            where x.VehicleType.TypeDescription == "New"
                            select x).OrderByDescending(x => x.MSRP).ToList();
            return vehicles;
        }

        public Role GetRoleById(int id)
        {
            var role = (from x in context.Roless
                        where x.RoleId == id
                        select x).FirstOrDefault();
            return role;
        }

        public Vehicle GetSingleVehicle(int id)
        {
            var vehicle = (from v in context.Vehicles
                           where v.VehicleId == id
                           select v).FirstOrDefault();
            return vehicle;
        }

        public Transmission GetTransmissionById(int id)
        {
            var trans = (from x in context.Transmissions
                         where x.TransmissionId == id
                         select x).FirstOrDefault();
            return trans;
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

        public VehicleType GetVehicleTypeById(int id)
        {
            var type = (from x in context.VehicleTypes
                        where x.VehicleTypeId == id
                        select x).FirstOrDefault();
            return type;
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
                query = query.Where(x => x.SalePrice >= vehicle.MinPrice);
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

        public List<Purchase> SearchPurchases(TotalSalesViewModel purchase)
        {
            var query = context.Purchases.AsQueryable();        

            //No parameters
            if(!purchase.UserId.HasValue && purchase.FromDate == null && purchase.ToDate == null)
            {
                query = context.Purchases;
            }
            //Id null, from, to null
            if (!purchase.UserId.HasValue && purchase.FromDate != null && purchase.ToDate == null)
            {
                query = query.Where(x => x.DatePurchased >= purchase.FromDate);
            }
            //id null, from null, to
            if (!purchase.UserId.HasValue && purchase.FromDate == null && purchase.ToDate != null)
            {
                query = query.Where(x => x.DatePurchased <= purchase.ToDate);
            }
            //id null, from, to
            if (!purchase.UserId.HasValue && purchase.FromDate != null && purchase.ToDate != null)
            {
                var product = (from x in query
                               where x.DatePurchased >= purchase.FromDate && x.DatePurchased <= purchase.ToDate
                               select x).ToList();
                return product;
            }
            //id, from null, to null
            if (purchase.UserId.HasValue && purchase.FromDate == null && purchase.ToDate == null)
            {
                var product = (from x in query
                               where x.UserId == purchase.UserId
                               select x).ToList();
                return product;
            }
            //id, from null, to
            if (purchase.UserId.HasValue && purchase.FromDate == null && purchase.ToDate != null)
            {
                var product = (from x in query
                               where (x.UserId == purchase.UserId) && (x.DatePurchased <= purchase.ToDate)
                               select x).ToList();
                return product;
            }
            //id, from, to null
            if (purchase.UserId.HasValue && purchase.FromDate != null && purchase.ToDate == null)
            {
                var product = (from x in query
                               where (x.UserId == purchase.UserId) && (x.DatePurchased >= purchase.FromDate)
                               select x).ToList();
                return product;
            }
            //All parameters
            else if (purchase.UserId.HasValue && purchase.FromDate != null && purchase.ToDate != null)
            {
                var product = (from x in query
                               where (x.UserId == purchase.UserId) && (x.DatePurchased >= purchase.FromDate) && (x.DatePurchased <= purchase.ToDate)
                               select x).ToList();
                return product;
            }
            var res = from q in query
                      group q by q.UserId into g
                      select new
                      {
                          UserId = g.Key,
                          totalVehicles = g.Count(),
                          totalSales = g.Sum(r => r.PurchasePrice)
                      };
            return query.ToList();
        }

        public List<Vehicle> SearchSalesVehicles(SearchViewModel vehicle)
        {
            var query = context.Vehicles.Where(x => x.SoldOut.Equals(false) || x.VehicleType.TypeDescription.Equals("New") || x.VehicleType.TypeDescription.Equals("Used"));

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
                query = query.Where(x => x.SalePrice >= vehicle.MinPrice);
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

        public void UpdateVehicle(Vehicle vehicleToUpdate)
        {
            var trackedEntity = context.Vehicles.Find(vehicleToUpdate.VehicleId);
            context.Entry(trackedEntity).CurrentValues.SetValues(vehicleToUpdate);
            context.Entry(trackedEntity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
