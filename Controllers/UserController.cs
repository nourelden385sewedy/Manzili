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

        [HttpGet] // Get: User/Login
        public async Task<IActionResult> SignIn() => View("SignIn");

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM signVm)
        {
            if (!ModelState.IsValid)
                return View(signVm);

            var user = await _userService.LoginAsync(signVm);
            if (user == null)
            {
                TempData["AlertMessage"] = "Invalid Credentials, Try Again or Sign Up";
                ViewBag.Error = "Invalid Credentials";
                return View("SignIn");
            }

            // TODO: Add authentication/session logic
            return RedirectToAction("Index", "Home");
        }

        // -------------------------

        [HttpGet] // Get: User/Register
        public async Task<IActionResult> Register() => View("SignUp");

        [HttpPost]
        public async Task<IActionResult> Register(SignUpVM signUpVM)
        {

            /*if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Please fill in all required fields correctly.";
                return View(model);
            }*/

            var success = await _userService.RegisterAsync(signUpVM);
            if (!success)
            {
                ViewBag.Error = "Email already exists.";
                return View("SignUp");
            }

            return RedirectToAction("Index", "Home");
        }

        // -------------------------

    }
}

