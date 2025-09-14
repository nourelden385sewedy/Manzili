using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; } = null!;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MinimumPurchase { get; set; }
        public int UsageLimit { get; set; } = 1;

        public bool AppliesToAllServices { get; set; } = false; // MVP flag

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        // Navigation Property with the Service

        public int? ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; } = null!;

        public ICollection<DiscountUsage> UsageHistory { get; set; } = new List<DiscountUsage>();


        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
