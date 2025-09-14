using Manzili.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Manzili.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; }

        [MaxLength(15)]
        [RegularExpression(@"^01\d{9}$", ErrorMessage = "Phone number must be 11 digits and start with 01.")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required, MaxLength(256)]
        public string PasswordHash { get; set; }

        // Enums

        [Required]
        [Display(Name = "User Role")]
        public RolesEnum Role { get; set; } // Buyer, Provider, Admin


        // Navigation Properties
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        // Audit

        [Display(Name = "Account Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Account Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
