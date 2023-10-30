using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Smyrna_Prototype.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
