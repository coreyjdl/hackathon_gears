using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
