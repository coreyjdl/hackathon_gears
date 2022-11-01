using GearRequestDrafter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearRequestDrafter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DiskRepository dRepo = new DiskRepository();
            return View();
        }

        public ActionResult CreateGearsRequest()
        {
            return View();
        }

        public ActionResult CreateRoleTemplate()
        {
            return View();
        }

        
    }
}