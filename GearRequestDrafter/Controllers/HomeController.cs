using GearRequestDrafter.Models;
using GearRequestDrafter.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace GearRequestDrafter.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiskRepository diskRepository = new DiskRepository();

        public ActionResult Index()
        {

            //diskRepository.Read();
            return View();
        }

        public ActionResult CreateGearsRequest()
        {
            return View();
        }

        public ActionResult ReadLibrary()
        {
            var model = diskRepository.Read();
            return View(model);
        }

        //public ActionResult ReadLibrary(ProfileLibrary profileLibrary)
        //{
        //    var model = profileLibrary;
        //    return View(model);
        //}

        public ActionResult CreateRoleTemplate()
        {
            return View();
        }

        public ActionResult DeleteRoleFromLibrary(string roleName)
        {
            var profileLibrary = diskRepository.Read();

            profileLibrary.profileLibrary = profileLibrary.profileLibrary.Where(x => x.RoleName != roleName);

            diskRepository.Write(profileLibrary);
            return RedirectToAction("ReadLibrary");
        }
    }
}