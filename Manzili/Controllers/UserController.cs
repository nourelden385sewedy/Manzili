using Manzili.Models;
using Manzili.Services.UserService;
using Manzili.ViewModels;
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
        public async Task<IActionResult> Login() => View("Login");

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var user = await _userService.LoginAsync(login);
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
        public async Task<IActionResult> Register(SignUpVM signUpVM, string password)
        {
            var success = await _userService.RegisterAsync(signUpVM, password);
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

