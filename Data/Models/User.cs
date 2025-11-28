using System.ComponentModel.DataAnnotations;

namespace Manzili.Data.Models
{
    public enum UserRole
    {
        Buyer,
        Provider,
        Admin
    }
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? FullName { get; set; } = string.Empty;

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [Required, MaxLength(256)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public UserRole? Role { get; set; }

        public bool IsBlocked { get; set; } = false;

        public DateTime? BlockedUntil { get; set; }

        [MaxLength(255)]
        public string? BlockReason { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public ICollection<Address>? Addresses { get; set; }
        //public ICollection<Service>? Services { get; set; }
        //public ICollection<Order>? Orders { get; set; }
        //public ICollection<Review>? Reviews { get; set; }
        //public ICollection<Notification>? Notifications { get; set; }
        //public ICollection<DiscountUsage>? DiscountUsages { get; set; }
        //public ICollection<Payment>? Payments { get; set; }
    }
}
