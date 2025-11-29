using Manzili.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Manzili.ViewModels
{
    public class ProfileEditVM
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; }
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
        public List<AddressV>? Addresses { get; set; }

    }

    public class AddressV
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }

    
}
