using CarMast.Data;
using CarMast.Models.DataModels;
using CarMast.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMast.UI.Controllers
{
    public class AdminController : Controller
    {
        //Vehicles Page
        [HttpGet]
        public ActionResult Vehicles()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetVehiclesForSale();
            return View(model);
        }




        //Add Vehicle Page
        [HttpGet]
        public ActionResult AddVehicle()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = new VehicleAdminViewModel();
            model.SetMakes(repo.GetAllMakes());
            model.SetModels(repo.GetAllModels());
            model.SetTypes(repo.GetAllVehicleTypes());
            model.SetBodyStyles(repo.GetAllBodyStyles());
            model.SetTransmissions(repo.GetAllTransmissions());
            model.SetInteriorColors(repo.GetAllInteriorColors());
            model.SetExteriorColors(repo.GetAllExteriorColors());
            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleAdminViewModel model)
        {
            var repo = CarMasterRepoFactory.Create();
            int nextYear = DateTime.Now.Year + 1;

            string extension = Path.GetExtension(model.ImageUpload.FileName);

            Vehicle vehicle = new Vehicle();
            vehicle.ModelId = model.Vehicle.ModelId;
            vehicle.Model.MakeId = model.Vehicle.Model.MakeId;
            vehicle.VehicleTypeId = model.Vehicle.VehicleTypeId;
            vehicle.BodyStyleId = model.Vehicle.BodyStyleId;
            vehicle.Year = model.Vehicle.Year;
            vehicle.TransmissionId = model.Vehicle.TransmissionId;
            vehicle.ExteriorColorId = model.Vehicle.ExteriorColorId;
            vehicle.InteriorColorId = model.Vehicle.InteriorColorId;
            vehicle.MSRP = model.Vehicle.MSRP;
            vehicle.SalePrice = model.Vehicle.SalePrice;
            vehicle.SoldOut = false;
            vehicle.Featured = false;
            vehicle.VehicleDescription = model.Vehicle.VehicleDescription;
            vehicle.Vin = model.Vehicle.Vin;

            if (model.Vehicle.Year < 2000 || model.Vehicle.Year > nextYear)
            {
                ModelState.AddModelError("Vehicle.Year", "The vehicle year must be between the year 2000 and this year plus 1.");
            }
            if (model.Vehicle.VehicleType.VehicleTypeId.Equals(1) && model.Vehicle.Mileage > 1000 || model.Vehicle.Mileage < 0)
            {
                ModelState.AddModelError("Vehicle.VehicleType.VehicleTypeId", "New vehicle mileage must be between 0 and 1000.");
            }
            if (model.Vehicle.VehicleType.VehicleTypeId.Equals(2) && model.Vehicle.Mileage < 1000)
            {
                ModelState.AddModelError("Vehicle.VehicleType.VehicleTypeId", "Used vehicle mileage must be greater than 1000.");
            }
            if (string.IsNullOrWhiteSpace(model.Vehicle.Vin))
            {
                ModelState.AddModelError("Vehicle.Vin", "VIN# is required.");
            }
            if (model.Vehicle.MSRP < 1)
            {
                ModelState.AddModelError("Vehicle.MSRP", "MSRP must be a positive number.");
            }
            if (model.Vehicle.SalePrice < 1)
            {
                ModelState.AddModelError("Vehicle.SalePrice", "Sale Price must be a positive number.");
            }
            if (model.Vehicle.SalePrice > model.Vehicle.MSRP)
            {
                ModelState.AddModelError("", "Sale Price must not exceed MSRP.");
            }
            if (string.IsNullOrWhiteSpace(model.Vehicle.VehicleDescription))
            {
                ModelState.AddModelError("Vehicle.VehicleDescription", "Description is required.");
            }
            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                var ext = new string[] { ".png", ".jpg", ".jpeg", ".gif" };

                if (!ext.Contains(extension))
                {
                    ModelState.AddModelError("ImageUpload", "Image file must be a .png, .jpeg, .jpg, of .gif.");
                }
            }
            else
            {
                ModelState.AddModelError("ImageUpload", "Image is required.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        var filePath = Path.Combine(savePath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        vehicle.ImageFileName = Path.GetFileName(filePath);
                    }
                    repo.CreateVehicle(vehicle);
                    return RedirectToAction("EditVehicle", "Admin", new { id = model.Vehicle.VehicleId });
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var newModel = new VehicleAdminViewModel();
                newModel.SetMakes(repo.GetAllMakes());
                newModel.SetModels(repo.GetAllModels());
                newModel.SetBodyStyles(repo.GetAllBodyStyles());
                newModel.SetTransmissions(repo.GetAllTransmissions());
                newModel.SetInteriorColors(repo.GetAllInteriorColors());
                newModel.SetExteriorColors(repo.GetAllExteriorColors());
                return View(newModel);
            }

        }



        //Edit Vehicle Page
        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var repo = CarMasterRepoFactory.Create();
            var model = new VehicleAdminViewModel();
            model.Vehicle = CarMasterRepoFactory.Create().GetSingleVehicle(id);
            model.SetMakes(repo.GetAllMakes());
            model.SetModels(repo.GetAllModels());
            model.SetTypes(repo.GetAllVehicleTypes());
            model.SetBodyStyles(repo.GetAllBodyStyles());
            model.SetTransmissions(repo.GetAllTransmissions());
            model.SetInteriorColors(repo.GetAllInteriorColors());
            model.SetExteriorColors(repo.GetAllExteriorColors());
            return View(model);
        }


        [HttpPost]
        public ActionResult EditVehicle(VehicleAdminViewModel model)
        {
            var repo = CarMasterRepoFactory.Create();
            int nextYear = DateTime.Now.Year + 1;

            string extension = Path.GetExtension(model.ImageUpload.FileName);

            Vehicle vehicle = new Vehicle();
            vehicle.VehicleId = model.Vehicle.VehicleId;
            vehicle.ModelId = model.Vehicle.ModelId;
            vehicle.Model.MakeId = model.Vehicle.Model.MakeId;
            vehicle.VehicleTypeId = model.Vehicle.VehicleTypeId;
            vehicle.BodyStyleId = model.Vehicle.BodyStyleId;
            vehicle.Year = model.Vehicle.Year;
            vehicle.TransmissionId = model.Vehicle.TransmissionId;
            vehicle.ExteriorColorId = model.Vehicle.ExteriorColorId;
            vehicle.InteriorColorId = model.Vehicle.InteriorColorId;
            vehicle.MSRP = model.Vehicle.MSRP;
            vehicle.SalePrice = model.Vehicle.SalePrice;
            vehicle.SoldOut = model.Vehicle.SoldOut;
            vehicle.Featured = model.Vehicle.Featured;
            vehicle.VehicleDescription = model.Vehicle.VehicleDescription;
            vehicle.Vin = model.Vehicle.Vin;
            vehicle.ImageFileName = model.Vehicle.ImageFileName;

            if (model.Vehicle.Year < 2000 || model.Vehicle.Year > nextYear)
            {
                ModelState.AddModelError("Vehicle.Year", "The vehicle year must be between the year 2000 and this year plus 1.");
            }
            if (model.Vehicle.VehicleType.VehicleTypeId.Equals(1) && model.Vehicle.Mileage > 1000 || model.Vehicle.Mileage < 0)
            {
                ModelState.AddModelError("Vehicle.VehicleType.VehicleTypeId", "New vehicle mileage must be between 0 and 1000.");
            }
            if (model.Vehicle.VehicleType.VehicleTypeId.Equals(2) && model.Vehicle.Mileage < 1000)
            {
                ModelState.AddModelError("Vehicle.VehicleType.VehicleTypeId", "Used vehicle mileage must be greater than 1000.");
            }
            if (string.IsNullOrWhiteSpace(model.Vehicle.Vin))
            {
                ModelState.AddModelError("Vehicle.Vin", "VIN# is required.");
            }
            if (model.Vehicle.MSRP < 1)
            {
                ModelState.AddModelError("Vehicle.MSRP", "MSRP must be a positive number.");
            }
            if (model.Vehicle.SalePrice < 1)
            {
                ModelState.AddModelError("Vehicle.SalePrice", "Sale Price must be a positive number.");
            }
            if (model.Vehicle.SalePrice > model.Vehicle.MSRP)
            {
                ModelState.AddModelError("", "Sale Price must not exceed MSRP.");
            }
            if (string.IsNullOrWhiteSpace(model.Vehicle.VehicleDescription))
            {
                ModelState.AddModelError("Vehicle.VehicleDescription", "Description is required.");
            }
            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                var ext = new string[] { ".png", ".jpg", ".jpeg", ".gif" };

                if (!ext.Contains(extension))
                {
                    ModelState.AddModelError("ImageUpload", "Image file must be a .png, .jpeg, .jpg, of .gif.");
                }
            }
            else
            {
                ModelState.AddModelError("ImageUpload", "Image is required.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var old = repo.GetSingleVehicle(model.Vehicle.VehicleId);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        var filePath = Path.Combine(savePath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        vehicle.ImageFileName = Path.GetFileName(filePath);

                        //Delete old file
                        var oldPath = Path.Combine(savePath, old.ImageFileName);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        //if replace image, delete old one and replace                        
                        model.Vehicle.ImageFileName = old.ImageFileName;
                    }
                    //repo.UpdateVehicle(vehicle);
                    return RedirectToAction("EditVehicle", new { id = model.Vehicle.VehicleId });
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var newModel = new VehicleAdminViewModel();
                newModel.SetMakes(repo.GetAllMakes());
                newModel.SetModels(repo.GetAllModels());
                newModel.SetBodyStyles(repo.GetAllBodyStyles());
                newModel.SetTransmissions(repo.GetAllTransmissions());
                newModel.SetInteriorColors(repo.GetAllInteriorColors());
                newModel.SetExteriorColors(repo.GetAllExteriorColors());
                return View(newModel);
            }
        }


        //USERS
        [HttpGet]
        public ActionResult Users()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var model = new UserViewModel();
            model.SetRoles(CarMasterRepoFactory.Create().GetAllRoles());
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            var repo = CarMasterRepoFactory.Create();
            if (ModelState.IsValid)
            {
                repo.AddUser(user);
                return RedirectToAction("Users");
            }
            else
            {
                var model = new UserViewModel();
                model.SetRoles(CarMasterRepoFactory.Create().GetAllRoles());
                return View(model);
            }
        }

    }
}