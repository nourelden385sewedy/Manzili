using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Review
    {
        [Key]
        [Display(Name = "Review ID")]
        public int ReviewId { get; set; }

        [Range(1, 5)]
        [Display(Name = "Rating (1-5)")]
        public int Rating { get; set; } // 1 to 5

        [MaxLength(1000)]
        public string Comment { get; set; }

        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;

        // Navigation Property with the Buyer

        [Display(Name = "Order Item ID")]
        public int OrderItemId { get; set; }
        [ForeignKey("OrderItemId")]
        public OrderItem OrderItem { get; set; }

        // Navigation Property with the Buyer

        [Display(Name = "Reviewer ID")]
        public int ReviewerId { get; set; }
        [ForeignKey("ReviewerId")]
        public User Reviewer { get; set; }
    }
}
