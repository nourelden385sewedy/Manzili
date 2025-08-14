using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class OrderItem
    {
        [Key]
        [Display(Name = "Order Item ID")]
        public int OrderItemId { get; set; }
        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Price at Order")]
        public decimal PriceAtOrder { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Customization Notes")]
        public string CustomizationNotes { get; set; }

        // Navigation Property with the Order that item associated to

        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        // Navigation Property with the Order that item associated to

        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

        // Navigation Properties
        public ICollection<Review> Reviews { get; set; }
    }
}
