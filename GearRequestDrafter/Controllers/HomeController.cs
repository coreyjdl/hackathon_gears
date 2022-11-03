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

        public ActionResult CreateGearsRequest(RoleRequest model)
        {
            return View(model);
        }

        public ActionResult ReadLibrary()
        {
            var model = diskRepository.Read();
            return View(model);
        }
        public ActionResult EditRole(string roleName)
        {
            return View();
        }
        public ActionResult CreateRoleTemplate()
        {
            return View();
        }
         public ActionResult CreateRole(RoleRequest roleRequest)
        {
            //find if role name is already in repo
            var pLibrary = diskRepository.Read();
            bool exists = pLibrary.profileLibrary.Any(x=>x.RoleName == roleRequest.RoleName);
            if(exists)
            {
                ModelState.AddModelError("", "Role Already Exists");
                return View("CreateRoleTemplate");

            }
            else
            {
                pLibrary.profileLibrary.Append(roleRequest);
                var addRole = new RoleRequest() {
                    GearsRequests = new List<GearsRequest>(),
                    RoleName = roleRequest.RoleName
                };
                var newLibrary = new List<RoleRequest>();
                newLibrary.Add(addRole);
                foreach(var rr in pLibrary.profileLibrary)
                {
                    newLibrary.Add(rr);
                }
                diskRepository.Write(new ProfileLibrary() {profileLibrary = newLibrary });
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
            var handler = new GearsSubmissionHandler();
            handler.SubmitUserRequests(user);

            return RedirectToAction("CreateRequest", "Home", new { user.RoleName });
        }
    }
}