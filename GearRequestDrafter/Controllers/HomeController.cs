using GearRequestDrafter.Models;
using GearRequestDrafter.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using GearRequestDrafter.Handlers;

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

        public ActionResult CreateRequest(RoleRequest roleRequest)
        {
            var model = new User()
            {
                RoleName = roleRequest.RoleName,
                GearsRequests = roleRequest.GearsRequests
            };

            return View(model);
        }

        public ActionResult SubmitRequest(User user)
        {
            var handler = new GearsSubmissionHandler();
            handler.SubmitUserRequests(user);

            return View("ReadLibrary");
        }
    }
}