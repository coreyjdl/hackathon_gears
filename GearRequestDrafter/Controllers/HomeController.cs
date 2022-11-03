using GearRequestDrafter.Models;
using GearRequestDrafter.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using GearRequestDrafter.Handlers;
using System.Web.Services.Description;

namespace GearRequestDrafter.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiskRepository diskRepository = new DiskRepository();

        public ActionResult Index()
        {

            //diskRepository.Read();
            return RedirectToAction("ReadLibrary");
        }

        public ActionResult CreateGearsRequest(string roleName)
        {

            ViewData["RoleName"] = roleName;
            return View();
        }

        public ActionResult ConfirmDone(GearsRequest model)
        {
            return View(model);
        }
        public ActionResult AddGearsRequestToRole(GearsRequest model)
        {
            ProfileLibrary pLibrary = diskRepository.Read();
            RoleRequest newRoleRequest = pLibrary.profileLibrary.Single(x => x.RoleName == model.RoleName);

            newRoleRequest.GearsRequests.Append(model);

            pLibrary.profileLibrary.Append(newRoleRequest);
            diskRepository.Write(pLibrary);
            return RedirectToAction("ReadLibrary");
        }

        public ActionResult ReadLibrary()
        {
            var model = diskRepository.Read();
            return View(model);
        }

        public ActionResult CreateRoleTemplate()
        {
            return View();
        }
        public ActionResult CreateRole(RoleRequest roleRequest)
        {
            //find if role name is already in repo
            var pLibrary = diskRepository.Read();
            bool exists = pLibrary.profileLibrary.Any(x => x.RoleName == roleRequest.RoleName);
            if (exists)
            {
                ModelState.AddModelError("", "Role Already Exists");
                return View("CreateRoleTemplate");

            }
            else
            {
                pLibrary.profileLibrary.Append(roleRequest);
                var addRole = new RoleRequest()
                {
                    GearsRequests = new List<GearsRequest>(),
                    RoleName = roleRequest.RoleName
                };
                var newLibrary = new List<RoleRequest>();
                newLibrary.Add(addRole);
                foreach (var rr in pLibrary.profileLibrary)
                {
                    newLibrary.Add(rr);
                }
                diskRepository.Write(new ProfileLibrary() { profileLibrary = newLibrary });
                return RedirectToAction("ReadLibrary");
            }

        }

        public ActionResult DeleteRoleFromLibrary(string roleName)
        {
            var profileLibrary = diskRepository.Read();

            profileLibrary.profileLibrary = profileLibrary.profileLibrary.Where(x => x.RoleName != roleName);

            diskRepository.Write(profileLibrary);
            return RedirectToAction("ReadLibrary");
        }

        public ActionResult CreateRequest(string roleName)
        {
            var pLibrary = diskRepository.Read();
            var role = pLibrary.profileLibrary.Where(x => x.RoleName == roleName).FirstOrDefault();

            var model = new User()
            {
                RoleName = role.RoleName,
                GearsRequests = role.GearsRequests
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateRequest(User user)
        {
            var pLibrary = diskRepository.Read();
            var role = pLibrary.profileLibrary.Where(x => x.RoleName == user.RoleName).FirstOrDefault();

            var request = new User()
            {
                RoleName = role.RoleName,
                GearsRequests = role.GearsRequests
            };

            var handler = new GearsSubmissionHandler();
            handler.SubmitUserRequests(request);

            return RedirectToAction("CreateRequest", "Home", new { user.RoleName });
        }
    }
}