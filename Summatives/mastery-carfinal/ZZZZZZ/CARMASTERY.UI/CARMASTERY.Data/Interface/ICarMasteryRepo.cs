using CARMASTERY.Models.DataModels;
using CARMASTERY.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Data.Interface
{
    public interface ICarMasteryRepo
    {
        //Colors
        List<ExteriorColor> GetAllExteriorColors();
        List<InteriorColor> GetAllInteriorColors();
        ExteriorColor GetExteriorColorById(int id);
        InteriorColor GetInteriorColorById(int id);

        //Makes
        List<Make> GetAllMakes();
        void CreateMake(Make makeToCreate);

        //Models
        List<Model> GetAllModels();
        void CreateModel(Model modelToCreate);
        Make GetMakeById(int id);
        Model GetModelById(int id);
        List<Model> GetModelByMakeId(int makeId);

        //Tran
        List<Transmission> GetAllTransmissions();
        Transmission GetTransmissionById(int id);

        //Style
        List<BodyStyle> GetAllBodyStyles();
        BodyStyle GetBodyStyleById(int id);

        //State
        List<State> GetAllStates();

        //Users
        List<User> GetAllUsers();
        void AddUser(User user);
        void EditUser(User userToEdit);
        User GetUserById(int id);

        //Vehicle Types
        List<VehicleType> GetAllVehicleTypes();
        VehicleType GetVehicleTypeById(int id);

        //Roles
        List<Role> GetAllRoles();
        Role GetRoleById(int id);


        //Vehicles
        List<Vehicle> GetAllPurchasedVehicles();
        List<Vehicle> GetFeaturedVehicles();
        List<Vehicle> GetNewVehicles();
        List<Vehicle> GetUsedVehicles();
        List<Vehicle> GetVehiclesForSale();
        List<Vehicle> GetAllVehicles();
        Vehicle GetSingleVehicle(int id);
        void CreateVehicle(Vehicle vehicleToCreate);
        void DeleteVehicle(int id);
        void UpdateVehicle(Vehicle vehicleToUpdate);

        //Specials
        void DeleteSpecial(int id);
        void CreateSpecial(Special special);
        Special GetById(int id);
        List<Special> GetAllSpecials();

        //Contact
        void CreateContact(Contact newContact);
        List<Contact> GetAllContacts();

        //Purchase
        List<PurchaseType> GetAllPurchaseTypes();
        List<Purchase> GetAllPurchases();
        void AddPurchase(Purchase purchase);
        List<Purchase> GetAllPurchasesBySingleUser(int id);
        

        //Search for used, new, (Admin)available for purchase, sale(all vehicles, minus purchased)
        List<Vehicle> SearchNewVehicles(SearchViewModel vehicle);
        List<Vehicle> SearchUsedVehicles(SearchViewModel vehicle);
        List<Vehicle> SearchSalesVehicles(SearchViewModel vehicle);
        List<Purchase> SearchPurchases(TotalSalesViewModel purchase);
    }
}
