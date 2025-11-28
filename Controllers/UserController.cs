using Microsoft.AspNetCore.Mvc;

namespace Manzili.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
