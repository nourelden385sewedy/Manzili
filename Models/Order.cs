using Manzili.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal SubTotal { get; set; }   // before discounts + delivery

        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal DeliveryFee { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }   // SubTotal - Discount + DeliveryFee

        [Required]
        public bool IsConfirmed { get; set; } = false; // seller approval

        [Required]
        public OrderStatusEnum Status { get; set; } // Pending, Confirmed, Completed, Cancelled


        // Navigation Property with the Buyer

        public int? BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public User Buyer { get; set; } = null!;


        // Navigation Properties
        public ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();


        public Payment Payment { get; set; } = null!;


        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
