using System.ComponentModel.DataAnnotations;

namespace Manzili.Enums
{
    public enum PaymentMethodEnum
    {
        [Display(Name = "Credit Card")]
        CreditCard,
        Cash,
        PayPal,
        etc
    }
}
