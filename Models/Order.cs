using Manzili.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public OrderStatusEnum Status { get; set; } // Pending, Confirmed, Completed, Cancelled
        
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        // Navigation Property with the Buyer

        [Display(Name = "Buyer ID")]
        public int BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public User Buyer { get; set; }

        // Navigation Properties
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
