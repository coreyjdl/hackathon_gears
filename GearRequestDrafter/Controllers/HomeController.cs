using GearRequestDrafter.Models;
using GearRequestDrafter.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearRequestDrafter.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiskRepository diskRepository = new DiskRepository();
        
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
            return View(diskRepository.Read());
        }

        public ActionResult CreateRoleTemplate()
        {
            return View();
        }

        
    }
}