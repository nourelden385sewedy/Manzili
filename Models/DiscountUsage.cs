using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class DiscountUsage
    {
        [Key]
        public int Id { get; set; }


        // Navigation property with the Discount

        [Required]
        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; } = null!;


        // Navigation property with the User who used the discount

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;


        // Optional: store order info
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }


        // Audit
        public DateTime UsedAt { get; set; } = DateTime.UtcNow;

    }
}
