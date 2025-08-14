using Manzili.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manzili.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Display(Name = "Full Name")]
        [Required, MaxLength(200)]
        public string FullName { get; set; }

        [Required, MaxLength(200), EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Phone number must be 11 digits and start with 01.")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public RolesEnum Role { get; set; } // Buyer, Provider, Admin

        [Required, MaxLength(256)]
        public string PasswordHash { get; set; }

        [MaxLength(256)]
        public string? PasswordSalt { get; set; }

        [Display(Name = "Account Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<Service> Services { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
