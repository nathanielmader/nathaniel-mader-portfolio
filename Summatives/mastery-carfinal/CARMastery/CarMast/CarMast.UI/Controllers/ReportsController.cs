using CarMast.Data;
using CarMast.Models.DataModels;
using CarMast.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMast.UI.Controllers
{
    public class ReportsController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            var repo = CarMasterRepoFactory.Create();

            var vehicles = repo.GetVehiclesForSale();
            var newVehicleList = vehicles.Where(x => x.VehicleType.Equals("New"));
            var usedVehicleList = vehicles.Where(x => x.VehicleType.Equals("Used"));

            InventoryViewModel model = new InventoryViewModel();
            model.NewVehicles = newVehicleList.ToList();
            model.UsedVehicles = usedVehicleList.ToList();
            return View();
        }
    }
}
