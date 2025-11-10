using System.ComponentModel.DataAnnotations;

namespace Manzili.ViewModels
{
    public class SignUpVM
    {
        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$\r\n",
            ErrorMessage = "Password must be at least 8 characters long"), Required]
        public string Password { get; set; }

        public bool isSeller { get; set; }

    }
}
