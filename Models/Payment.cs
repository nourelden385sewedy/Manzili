using Manzili.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; } // CreditCard, Cash, PayPal, etc.

        [MaxLength(100)]
        public string TransactionId { get; set; } = null!;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public PaymentStatusEnum Status { get; set; } // Pending, Paid, Failed, Refunded

        // Navigation Property with the Order

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;

        // Navigation Property with Buyer (User who paid for the order)

        public int? BuyerId { get; set; }

        [ForeignKey("OrderId")]
        public User? Buyer { get; set; }

    }
}
