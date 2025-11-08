using Manzili.Models;
using Manzili.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Manzili.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] // Get: User/Login
        public async Task<IActionResult> Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email,[FromBody] string password)
        {
            var user = await _userService.LoginAsync(email, password);
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View();
            }

            // TODO: Add authentication/session logic
            return RedirectToAction("Index");
        }


        [HttpGet] // Get: User/Register
        public async Task<IActionResult> Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(User user, string password)
        {
            var success = await _userService.RegisterAsync(user, password);
            if (!success)
            {
                ViewBag.Error = "Email already exists.";
                return View();
            }

            return RedirectToAction("Profile");
        }

        // to Get the Profile Page
        public IActionResult Profile() => View();
    }
}

