using CARMASTERY.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Controllers
{
    public class InventoryController : Controller
    {
        [HttpGet]
        public ActionResult New()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetNewVehicles();
            return View(model);
        }

        [HttpGet]
        public ActionResult Used()
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetUsedVehicles();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var repo = CarMasterRepoFactory.Create();
            var model = repo.GetSingleVehicle(id);
            return View(model);
        }
    }
}