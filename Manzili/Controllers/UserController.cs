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
            if (!ModelState.IsValid)
                return View(login);

            var user = await _userService.LoginAsync(login);
            if (user == null)
            {
                TempData["AlertMessage"] = "Invalid Credentials, Try Again or Sign Up";
                ViewBag.Error = "Invalid Credentials";
                return View();
            }

            // TODO: Add authentication/session logic
            return RedirectToAction("Index","Home");
        }


        [HttpGet] // Get: User/Register
        public async Task<IActionResult> Register() => View("SignUp");

        [HttpPost]
        public async Task<IActionResult> Register(SignUpVM signUpVM, string password)
        {

            //if (!ModelState.IsValid)
            //{
            //    TempData["AlertMessage"] = "Please fill in all required fields correctly.";
            //    return View(model);
            //}

            //// Example: Check if email already exists
            //bool emailExists = false; // Replace with your DB check
            //if (emailExists)
            //{
            //    TempData["AlertMessage"] = "This email is already registered.";
            //    return View(model);
            //}

            //// Save user logic here
            //TempData["AlertMessage"] = "Account created successfully!";
            //return RedirectToAction("Login");
        

        var success = await _userService.RegisterAsync(signUpVM, password);
            if (!success)
            {
                ViewBag.Error = "Email already exists.";
                return View();
            }

            return RedirectToAction("Profile");
        }

        // to Get the Profile Page
        public IActionResult Profile() => View("Privacy");
    }
}

