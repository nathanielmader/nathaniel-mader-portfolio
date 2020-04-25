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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetFeaturedVehicles();
            return View(model);
        }

        //CONTACT
        [HttpGet]//Should simply return a view. No data to retrieve initially
        public ActionResult Contact()
        {
            return View();
        }

        //Need to add functionality
        //Need to add when contactbutton clicked, add vin
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            var repo = CarMasterRepoFactory.Create();
            if (string.IsNullOrWhiteSpace(contact.Email) || string.IsNullOrWhiteSpace(contact.Phone))
            {
                ModelState.AddModelError("", "Either phone number or email must be provided.");
            }

            if (ModelState.IsValid)
            {
                repo.CreateContact(contact);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //SPECIALS
        [HttpGet]//Get specials from database
        public ActionResult Special()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetAllSpecials();
            return View(model);
        }
    }
}