using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class OrderService
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;

        [MaxLength(2000)]
        public string? CustomizationDetails { get; set; } // buyer-specific request

        [Column(TypeName = "decimal(10,2)")]
        public decimal PriceAtOrder { get; set; } // store price snapshot

        [MaxLength(200)]
        public string ServiceTitleAtOrder { get; set; } = null!; // store title snapshot


        // Navigation Property with the Order that item associated to

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;

        // Navigation Property with the Service

        [Required]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; } = null!;


        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
