using CARMASTERY.Data;
using CARMASTERY.Models.DataModels;
using CARMASTERY.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Controllers
{
    public class SaleController : Controller
    {
        public ActionResult SaleDirectory()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetAllVehicles();
            return View(model);
        }


        //PURCHASE
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

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            var repo = CarMasterRepoFactory.Create();
            var vehicle = repo.GetSingleVehicle(model.Vehicle.VehicleId);
            var user = repo.GetUserById(1);


            if (string.IsNullOrWhiteSpace(model.Purchase.Name))
            {
                ModelState.AddModelError("Purchase.Name", "Name is required.");
            }
            if (string.IsNullOrWhiteSpace(model.Purchase.Phone) && string.IsNullOrWhiteSpace(model.Purchase.Email))
            {
                ModelState.AddModelError("Purchase.Phone", "Phone or email required.");
            }
            if (string.IsNullOrWhiteSpace(model.Purchase.StreetAddress1))
            {
                ModelState.AddModelError("Purchase.StreetAddress1", "Street Address 1 is required.");
            }
            if (string.IsNullOrWhiteSpace(model.Purchase.City))
            {
                ModelState.AddModelError("Purchase.City", "City is required.");
            }
            if (model.Purchase.ZipCode.ToString().Length < 5 || model.Purchase.ZipCode.ToString().Length > 5)
            {
                ModelState.AddModelError("Purchase.ZipCode", "Zipcode must be 5 digits long.");
            }
            if (model.Purchase.PurchasePrice < vehicle.SalePrice * 95 / 100)
            {
                ModelState.AddModelError("Purchase.PurchasePrice", "Purchase price cannot be less than 95% of the sales price.");
            }
            if (model.Purchase.PurchasePrice > vehicle.MSRP)
            {
                ModelState.AddModelError("Purchase.PurchasePrice", "Purchase price may not exceed MSRP");
            }

            if (ModelState.IsValid)
            {
                Purchase purchase = new Purchase();
                purchase.Name = model.Purchase.Name;
                purchase.Phone = model.Purchase.Phone;
                purchase.Email = model.Purchase.Email;
                purchase.StreetAddress1 = model.Purchase.StreetAddress1;
                purchase.StreetAddress2 = model.Purchase.StreetAddress2;
                purchase.City = model.Purchase.City;
                purchase.ZipCode = model.Purchase.ZipCode;
                purchase.PurchasePrice = model.Purchase.PurchasePrice;
                purchase.DatePurchased = DateTime.Now;
                purchase.PurchaseTypeId = model.Purchase.PurchaseTypeId;
                purchase.StateId = model.Purchase.StateId;
                purchase.Vehicle = vehicle;
                purchase.VehicleId = model.Vehicle.VehicleId;              
                purchase.UserId = user.UserId;
                purchase.Vehicle.SoldOut = true;
                purchase.Vehicle.Featured = false;
                //model.Purchase.Vehicle.SoldOut = true;
                //model.Purchase.Vehicle.Featured = false;

                vehicle.SoldOut = true;
                vehicle.Featured = false;

                repo.UpdateVehicle(model.Vehicle);
                repo.AddPurchase(purchase);
                return RedirectToAction("Index");
            }
            else
            {
                //var repo = CarMasterRepoFactory.Create();
                var newModel = new PurchaseViewModel();
                newModel.Vehicle = repo.GetSingleVehicle(model.Vehicle.VehicleId);
                newModel.SetPurchaseTypes(repo.GetAllPurchaseTypes());
                newModel.SetStates(repo.GetAllStates());
                return View(newModel);
            }
        }


        //MAKES
        [HttpGet]
        public ActionResult Makes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Makes(Make makeToAdd)
        {
            var repo = CarMasterRepoFactory.Create();
            repo.CreateMake(makeToAdd);
            return RedirectToAction("Makes");
        }



        //MODELS
        [HttpGet]
        public ActionResult Models()
        {
            var repo = CarMasterRepoFactory.Create();
            AddModelViewModel model = new AddModelViewModel();
            model.SetMakesList(repo.GetAllMakes());
            return View(model);
        }

        [HttpPost]
        public ActionResult AddModel(AddModelViewModel modelToCreate)
        {
            //VM-Model and makeslist
            //Model
            //ModelId, ModelDescription, DateAdded, MakeId
            var repo = CarMasterRepoFactory.Create();

            if (ModelState.IsValid)
            {
                //Model newModel = new Model();
                //modelToCreate.Model.DateAdded = DateTime.Now;
                //m.Model.DateAdded = DateTime.Now;
                //newModel.ModelDescription = m.Model.ModelDescription;
                //newModel.Make.MakeId = m.Model.Make.MakeId;
                repo.CreateModel(modelToCreate.Model);
                return RedirectToAction("Models");
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