using Manzili.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Payment
    {
        [Key]
        [Display(Name = "Payment ID")]
        public int PaymentId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; } // CreditCard, Cash, PayPal, etc.

        [MaxLength(100)]
        [Display(Name = "Transaction ID")]
        public string TransactionId { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public ServiceStatusEnum Status { get; set; } // Pending, Paid, Failed, Refunded

        // Navigation Property with the Buyer

        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
