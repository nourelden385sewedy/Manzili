using Manzili.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;

        [MaxLength(3000)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; } = null!;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public ServiceStatusEnum Status { get; set; } // Active, Inactive, Draft
        public bool IsAvailable { get; set; } = true; // indicates if it will shown to the user or not


        // MVP Analytics
        public int OrdersCount { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Revenue { get; set; } = 0;
        public int ViewsCount { get; set; } = 0;

        public bool IsFeatured { get; set; } = false;
        public bool IsRecommended { get; set; } = false;


        // Navigation Property with the Seller

        [Required]
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public User Provider { get; set; } = null!;

        // Navigation Properties
        public ICollection<ServiceImage> Images { get; set; } = new List<ServiceImage>();
        public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Discount> Discounts { get; set; } = new List<Discount>();


        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
