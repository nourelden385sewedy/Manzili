using System.ComponentModel.DataAnnotations;

namespace Manzili.ViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public string Email { get; set; }

        //[RegularExpression("",
        //    ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        public bool isSeller { get; set; }
    }
}
