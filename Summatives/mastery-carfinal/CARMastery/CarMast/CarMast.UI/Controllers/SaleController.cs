using CarMast.Data;
using CarMast.Models.DataModels;
using CarMast.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMast.UI.Controllers
{
    public class SaleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetAllVehicles();
            return View(model);
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            var repo = CarMasterRepoFactory.Create();
            var model = new PurchaseViewModel();
            model.Vehicle = repo.GetSingleVehicle(id);
            model.SetPurchaseTypes(repo.GetAllPurchaseTypes());
            model.SetStates(repo.GetAllStates());
            return View(model);
        }

        //Check logic with Randall
        [HttpPost]
        public ActionResult Purchase(Purchase purchase)
        {
            var repo = CarMasterRepoFactory.Create();
            var vehicle = repo.GetSingleVehicle(purchase.Vehicle.VehicleId);
            var user = repo.GetUserById(1);
            purchase.DatePurchased = DateTime.Now;
            purchase.User = user;
            purchase.Vehicle = vehicle;
            purchase.Vehicle.SoldOut = true;
            purchase.Vehicle.Featured = false;

            if (string.IsNullOrWhiteSpace(purchase.Name))
            {
                ModelState.AddModelError("Purchase.Name", "Name is required.");
            }
            if (string.IsNullOrWhiteSpace(purchase.Phone) && string.IsNullOrWhiteSpace(purchase.Email))
            {
                ModelState.AddModelError("Purchase.Phone", "Phone or email required.");
            }
            if (string.IsNullOrWhiteSpace(purchase.StreetAddress1))
            {
                ModelState.AddModelError("Purchase.StreetAddress1", "Street Address 1 is required.");
            }
            if (string.IsNullOrWhiteSpace(purchase.City))
            {
                ModelState.AddModelError("Purchase.City", "City is required.");
            }
            if (purchase.ZipCode.ToString().Length < 5 || purchase.ZipCode.ToString().Length > 5)
            {
                ModelState.AddModelError("Purchase.ZipCode", "Zipcode must be 5 digits long.");
            }
            if (purchase.PurchasePrice < vehicle.SalePrice * 95/100)
            {
               ModelState.AddModelError("Purchase.PurchasePrice", "Purchase price cannot be less than 95% of the sales price.");
            }
            if (purchase.PurchasePrice > vehicle.MSRP)
            {
                ModelState.AddModelError("Purchase.PurchasePrice", "Purchase price may not exceed MSRP");
            }
            if (ModelState.IsValid)
            {
                repo.AddPurchase(purchase);
                return RedirectToAction("Index");
            }
            else
            {
                var model = new PurchaseViewModel();
                model.Vehicle = repo.GetSingleVehicle(model.Vehicle.VehicleId);
                model.SetPurchaseTypes(repo.GetAllPurchaseTypes());
                model.SetStates(repo.GetAllStates());
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Makes()
        {
            //var repo = CarMasterRepoFactory.Create();
            //var model = repo.GetAllMakes();
            return View();
        }

        //Not saving user -- needs work after identity with Randall
        [HttpPost]
        public ActionResult Makes(Make makeToAdd)
        {
            var repo = CarMasterRepoFactory.Create();
            repo.CreateMake(makeToAdd);
            return RedirectToAction("Makes", "Sales");
        }

        //[HttpGet]
        //public ActionResult ListMakes()
        //{
        //    var repo = CarMasterRepoFactory.Create();
        //    var model = repo.GetAllMakes();
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult Models()
        {
            var repo = CarMasterRepoFactory.Create();
            AddModelViewModel model = new AddModelViewModel();
            model.SetMakesList(repo.GetAllMakes());
            return View(model);
        }

        //ERRORS
        //Make errors
        [HttpPost]
        public ActionResult AddModel(AddModelViewModel model)
        {
            var repo = CarMasterRepoFactory.Create();
            Model newModel = new Model();
            newModel.ModelDescription = model.Model.ModelDescription;
            newModel.Make.MakeId = model.Model.MakeId;
            var make = repo.GetMakeById(newModel.Make.MakeId);
            newModel.Make = make;

            if (ModelState.IsValid)
            {
                repo.CreateModel(newModel);
                return RedirectToAction("Models", "Sale");
            }
            else
            {
                AddModelViewModel result = new AddModelViewModel();
                result.SetMakesList(repo.GetAllMakes());
                return View(result);
            }
        }
    }
}