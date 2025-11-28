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

        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }

        public bool isSeller { get; set; }
    }
}
