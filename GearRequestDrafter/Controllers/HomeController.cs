using GearRequestDrafter.Models;
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

            //DiskRepository.Read();
            return View();
        }

        public ActionResult CreateGearsRequest()
        {
            return View();
        }

        public ActionResult ReadLibrary()
        {
            return View(DiskRepository.Read());
        }

        public ActionResult CreateRoleTemplate()
        {
            return View();
        }

        
    }
}