using System.ComponentModel.DataAnnotations;

namespace Manzili.ViewModels
{
    public class SignInVM
    {
        [EmailAddress(ErrorMessage = "Must be a valid email address that contains '@'"),
            Required(ErrorMessage = "Email Address can't be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }

        public bool isSeller { get; set; }
    }
}
