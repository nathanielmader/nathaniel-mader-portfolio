using CARMASTERY.Data;
using CARMASTERY.Models.DataModels;
using CARMASTERY.Models.ViewModels;
using CARMASTERY.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CARMASTERY.UI.Controllers
{
    public class AdminController : Controller
    {
        //Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //USERS
        [HttpGet]
        public ActionResult Users()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetAllUsers();
            return View(model);
        }

        //ADD USER
        [HttpGet]
        public ActionResult AddUser()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = new UserViewModel();
            model.SetRoles(repo.GetAllRoles());
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            var repo = CarMasterRepoFactory.Create();
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Error: Passwords do not match");
            }
            else if (string.IsNullOrEmpty(model.User.FirstName))
            {
                ModelState.AddModelError("FirstName", "Please enter a firstname");
            }
            if (ModelState.IsValid)
            {
                User userToCreate = new User();
                userToCreate.FirstName = model.User.FirstName;
                userToCreate.LastName = model.User.LastName;
                userToCreate.Email = model.User.Email;
                userToCreate.Password = model.User.Password;
                userToCreate.ConfirmPassword = model.User.ConfirmPassword;
                userToCreate.Role = model.User.Role;

                repo.AddUser(userToCreate);
                return RedirectToAction("Users");
            }
            else
            {
                var newModel = new UserViewModel();
                newModel.SetRoles(CarMasterRepoFactory.Create().GetAllRoles());
                return View(newModel);
            }
        }

        //EDIT USER
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var repo = CarMasterRepoFactory.Create();
            var model = new UserViewModel();
            model.User = repo.GetUserById(id);
            model.SetRoles(CarMasterRepoFactory.Create().GetAllRoles());
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            var repo = CarMasterRepoFactory.Create();
            if (user.Password != user.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Error: Passwords do not match");
            }
            if (ModelState.IsValid)
            {
                repo.EditUser(user);
                return RedirectToAction("Users");
            }
            else
            {
                var model = new UserViewModel();
                model.User = repo.GetUserById(user.UserId);
                model.SetRoles(CarMasterRepoFactory.Create().GetAllRoles());
                return View(model);
            }
        }

        //SPECIALS
        public ActionResult Specials()
        {
            var repo = CarMasterRepoFactory.Create();
            AminSpecialVM model = new AminSpecialVM();
            model.SpecialsList = repo.GetAllSpecials();
            return View(model);
        }


        //Admin permission only
        //Error-believe 
        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            var repo = CarMasterRepoFactory.Create();
            if (ModelState.IsValid)
            {
                repo.DeleteSpecial(id);

                return RedirectToAction("Specials");
            }
            else
            {
                //AminSpecialVM newModel = new AminSpecialVM();
                //newModel.SpecialsList = repo.GetAllSpecials();
                return RedirectToAction("Specials");
            }
        }

        //Save/create works
        [HttpPost]
        public ActionResult CreateSpecial(AminSpecialVM model)
        {
            var repo = CarMasterRepoFactory.Create();
            if (ModelState.IsValid)
            {
                Special special = new Special();
                special.SpecialTitle = model.Special.SpecialTitle;
                special.SpecialDescription = model.Special.SpecialDescription;

                repo.CreateSpecial(special);

                return RedirectToAction("Specials");
            }
            else
            {
                AminSpecialVM newModel = new AminSpecialVM();
                newModel.SpecialsList = repo.GetAllSpecials();
                return View(newModel);
            }
        }

        public ActionResult DeleteVehicle(int id)
        {
            var repo = CarMasterRepoFactory.Create();
            if (ModelState.IsValid)
            {
                repo.DeleteVehicle(id);

                return RedirectToAction("Vehicles");
            }
            else
            {
                return RedirectToAction("Vehicles");
            }
        }

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
            if (ModelState.IsValid)
            {
                try
                {
                    //Vehicle vehicle = new Vehicle();
                    //vehicle.ModelId = model.Vehicle.ModelId;
                    //vehicle.VehicleTypeId = model.Vehicle.VehicleTypeId;
                    //vehicle.BodyStyleId = model.Vehicle.BodyStyleId;
                    //vehicle.Year = model.Vehicle.Year;
                    //vehicle.TransmissionId = model.Vehicle.TransmissionId;
                    //vehicle.ExteriorColorId = model.Vehicle.ExteriorColorId;
                    //vehicle.InteriorColorId = model.Vehicle.InteriorColorId;
                    //vehicle.MSRP = model.Vehicle.MSRP;
                    //vehicle.SalePrice = model.Vehicle.SalePrice;
                    //vehicle.SoldOut = false;
                    //vehicle.Featured = false;
                    //vehicle.VehicleDescription = model.Vehicle.VehicleDescription;
                    //vehicle.Vin = model.Vehicle.Vin;
                    //model.Vehicle.DateModified = null;
                    string extension = Path.GetExtension(model.ImageUpload.FileName);
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
                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);
                    }
                    
                }

                catch
                {
                    
                    Console.WriteLine("Error");
                }
                repo.CreateVehicle(model.Vehicle);
                return RedirectToAction("EditVehicle", "Admin", new { id = model.Vehicle.VehicleId });
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
        public ActionResult EditVehicle(VehicleAdminViewModel m)
        {
            //var repo = CarMasterRepoFactory.Create();
            //int nextYear = DateTime.Now.Year + 1;

            //if (model.Vehicle.Year < 2000 || model.Vehicle.Year > nextYear)
            //{
            //    ModelState.AddModelError("Vehicle.Year", "The vehicle year must be between the year 2000 and this year plus 1.");
            //}
            //if (model.Vehicle.VehicleType.VehicleTypeId.Equals(1) && model.Vehicle.Mileage > 1000 || model.Vehicle.Mileage < 0)
            //{
            //    ModelState.AddModelError("Vehicle.VehicleType.VehicleTypeId", "New vehicle mileage must be between 0 and 1000.");
            //}
            //if (model.Vehicle.VehicleType.VehicleTypeId.Equals(2) && model.Vehicle.Mileage < 1000)
            //{
            //    ModelState.AddModelError("Vehicle.VehicleType.VehicleTypeId", "Used vehicle mileage must be greater than 1000.");
            //}
            //if (string.IsNullOrWhiteSpace(model.Vehicle.Vin))
            //{
            //    ModelState.AddModelError("Vehicle.Vin", "VIN# is required.");
            //}
            //if (model.Vehicle.MSRP < 1)
            //{
            //    ModelState.AddModelError("Vehicle.MSRP", "MSRP must be a positive number.");
            //}
            //if (model.Vehicle.SalePrice < 1)
            //{
            //    ModelState.AddModelError("Vehicle.SalePrice", "Sale Price must be a positive number.");
            //}
            //if (model.Vehicle.SalePrice > model.Vehicle.MSRP)
            //{
            //    ModelState.AddModelError("", "Sale Price must not exceed MSRP.");
            //}
            //if (string.IsNullOrWhiteSpace(model.Vehicle.VehicleDescription))
            //{
            //    ModelState.AddModelError("Vehicle.VehicleDescription", "Description is required.");
            //}
            //if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            //{
            //    var ext = new string[] { ".png", ".jpg", ".jpeg", ".gif" };

            //    if (!ext.Contains(extension))
            //    {
            //        ModelState.AddModelError("ImageUpload", "Image file must be a .png, .jpeg, .jpg, of .gif.");
            //    }
            //}
            //else
            //{
            //    ModelState.AddModelError("ImageUpload", "Image is required.");
            //}
            
            if (ModelState.IsValid)
            {
                var repo = CarMasterRepoFactory.Create();
                try
                {
                    var old = repo.GetSingleVehicle(m.Vehicle.VehicleId);

                    if (m.ImageUpload != null && m.ImageUpload.ContentLength > 0)
                    {

                        var savePath = Server.MapPath("~/Images");

                        string extension = Path.GetExtension(m.ImageUpload.FileName);
                        string fileName = Path.GetFileNameWithoutExtension(m.ImageUpload.FileName);
                        var filePath = Path.Combine(savePath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        m.ImageUpload.SaveAs(filePath);
                        m.Vehicle.ImageFileName = Path.GetFileName(filePath);

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
                        m.Vehicle.ImageFileName = old.ImageFileName;
                    }
                    m.Vehicle.ModelId = m.Vehicle.Model.ModelId;
                    m.Vehicle.VehicleDescription = m.Vehicle.VehicleType.TypeDescription;
                    repo.UpdateVehicle(m.Vehicle);
                    return RedirectToAction("EditVehicle", new { id = m.Vehicle.VehicleId });
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var repo = CarMasterRepoFactory.Create();
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
    }
}