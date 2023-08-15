using Microsoft.AspNetCore.Mvc;

namespace Smyrna_Prototype.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Rehabilitation()
        {
            return View();
        }

        public IActionResult MissionarySchool()
        {
            return View();
        }

        public IActionResult OtherServices()
        {
            return View();
        }
    }
}
