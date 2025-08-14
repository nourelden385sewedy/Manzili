using Manzili.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Service
    {
        [Key]
        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public ServiceStatusEnum Status { get; set; } // Active, Inactive, Draft

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property with the Seller

        [Display(Name = "Seller ID")]
        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public User Seller { get; set; }

        // Navigation Properties
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ServiceImage> ServiceImages { get; set; }
    }
}
