using CARMASTERY.Data;
using CARMASTERY.Models.DataModels;
using CARMASTERY.Models.ViewModels;
using CARMASTERY.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Controllers
{
    public class ReportsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SalesReport()
        {
            var repo = CarMasterRepoFactory.Create();
            var users = repo.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            var repo = CarMasterRepoFactory.Create();

            var vehicles = repo.GetVehiclesForSale();
            var newVehicleList = vehicles.Where(x => x.VehicleType.TypeDescription.Equals("New"));
            var usedVehicleList = vehicles.Where(x => x.VehicleType.TypeDescription.Equals("Used"));

            //Set inventoryVM lists to new list of detailVM
            InventoryViewModel viewModel = new InventoryViewModel();
            viewModel.NewVehicles = new List<InventoryDetailsViewModel>();
            viewModel.UsedVehicles = new List<InventoryDetailsViewModel>();

            //List of new vehicles
            foreach (var vehicle in newVehicleList)
            {
                InventoryDetailsViewModel view = new InventoryDetailsViewModel();
                view.Year = vehicle.Year;
                view.Make = vehicle.Model.Make.MakeDescription;
                view.Model = vehicle.Model.ModelDescription;
                view.Count = newVehicleList.Count();
                view.StockValue = newVehicleList.Select(x => x.MSRP).Sum();
                viewModel.NewVehicles.Add(view);
            }
            //List of used vehicles
            foreach (var vehicle in usedVehicleList)
            {
                InventoryDetailsViewModel view = new InventoryDetailsViewModel();
                view.Year = vehicle.Year;
                view.Make = vehicle.Model.Make.MakeDescription;
                view.Model = vehicle.Model.ModelDescription;
                view.Count = usedVehicleList.Count();
                view.StockValue = usedVehicleList.Select(x => x.MSRP).Sum();
                viewModel.UsedVehicles.Add(view);
            }
            //Send list of new and used to view
            return View(viewModel);
        }

    }
}