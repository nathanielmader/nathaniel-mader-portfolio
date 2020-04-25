using CARMASTERY.Data.Interface;
using CARMASTERY.Models.DataModels;
using CARMASTERY.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Data.Repos
{
    public class MockRepo : ICarMasteryRepo
    {
        public void AddPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void CreateContact(Contact newContact)
        {
            throw new NotImplementedException();
        }

        public void CreateMake(Make makeToCreate)
        {
            throw new NotImplementedException();
        }

        public void CreateModel(Model modelToCreate)
        {
            throw new NotImplementedException();
        }

        public void CreateSpecial(Special special)
        {
            throw new NotImplementedException();
        }

        public void CreateVehicle(Vehicle vehicleToCreate)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecial(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User userToEdit)
        {
            throw new NotImplementedException();
        }

        public List<BodyStyle> GetAllBodyStyles()
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public List<ExteriorColor> GetAllExteriorColors()
        {
            throw new NotImplementedException();
        }

        public List<InteriorColor> GetAllInteriorColors()
        {
            throw new NotImplementedException();
        }

        public List<Make> GetAllMakes()
        {
            throw new NotImplementedException();
        }

        public List<Model> GetAllModels()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllPurchasedVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetAllPurchases()
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetAllPurchasesBySingleUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public List<Special> GetAllSpecials()
        {
            throw new NotImplementedException();
        }

        public List<State> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public List<Transmission> GetAllTransmissions()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            throw new NotImplementedException();
        }

        public BodyStyle GetBodyStyleById(int id)
        {
            throw new NotImplementedException();
        }

        public Special GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ExteriorColor GetExteriorColorById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            throw new NotImplementedException();
        }

        public InteriorColor GetInteriorColorById(int id)
        {
            throw new NotImplementedException();
        }

        public Make GetMakeById(int id)
        {
            throw new NotImplementedException();
        }

        public Model GetModelById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model> GetModelByMakeId(int makeId)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetNewVehicles()
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetSingleVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public Transmission GetTransmissionById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetUsedVehicles()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehiclesForSale()
        {
            throw new NotImplementedException();
        }

        public VehicleType GetVehicleTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> SearchNewVehicles(SearchViewModel vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> SearchPurchases(TotalSalesViewModel purchase)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> SearchSalesVehicles(SearchViewModel vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> SearchUsedVehicles(SearchViewModel vehicle)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(Vehicle vehicleToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
