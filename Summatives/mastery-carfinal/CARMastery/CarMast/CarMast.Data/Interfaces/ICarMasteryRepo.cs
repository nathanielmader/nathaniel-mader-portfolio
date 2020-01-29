using CarMast.Models.DataModels;
using CarMast.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMast.Data.Interfaces
{
    public interface ICarMasteryRepo
    {
        //Colors
        List<ExteriorColor> GetAllExteriorColors();
        List<InteriorColor> GetAllInteriorColors();

        //Makes
        List<Make> GetAllMakes();
        void CreateMake(Make makeToCreate);

        //Models
        List<Model> GetAllModels();
        void CreateModel(Model modelToCreate);
        Make GetMakeById(int id);

        //Tran
        List<Transmission> GetAllTransmissions();

        //Style
        List<BodyStyle> GetAllBodyStyles();

        //State
        List<State> GetAllStates();

        //Users
        List<User> GetAllUsers();
        void AddUser(User user);
        void EditUser(int id);
        User GetUserById(int id);

        //Vehicle Types
        List<VehicleType> GetAllVehicleTypes();

        //Roles
        List<Role> GetAllRoles();


        //Vehicles
        List<Vehicle> GetFeaturedVehicles();
        List<Vehicle> GetNewVehicles();
        List<Vehicle> GetUsedVehicles();
        List<Vehicle> GetVehiclesForSale();
        List<Vehicle> GetAllVehicles();
        Vehicle GetSingleVehicle(int id);
        void CreateVehicle(Vehicle vehicleToCreate);
        void DeleteVehicle(int id);

        //Specials
        void DeleteSpecial(int id);
        void CreateSpecial(Special specialToCreate);
        Special GetById(int id);
        List<Special> GetAllSpecials();

        //Contact
        void CreateContact(Contact newContact);
        List<Contact> GetAllContacts();

        //Purchase
        List<PurchaseType> GetAllPurchaseTypes();
        List<Purchase> GetAllPurchases();
        void AddPurchase(Purchase purchase);

        //Search for used, new, (Admin)available for purchase, sale(all vehicles, minus purchased)
        List<Vehicle> SearchNewVehicles(SearchViewModel vehicle);
        List<Vehicle> SearchUsedVehicles(SearchViewModel vehicle);
        List<Vehicle> SearchSalesVehicles(SearchViewModel vehicle);
    }
}
