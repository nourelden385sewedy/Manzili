using System.ComponentModel.DataAnnotations;

namespace Manzili.ViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$\r\n",
            ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
    }
}
