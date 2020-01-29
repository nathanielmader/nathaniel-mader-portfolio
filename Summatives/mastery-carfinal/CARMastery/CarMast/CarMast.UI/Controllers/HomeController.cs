using CarMast.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMast.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]//Should simply return a view. No data to retrieve initially
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]//Get specials from database
        public ActionResult Special()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetAllSpecials();
            return View(model);
        }
    }
}