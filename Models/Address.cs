using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Government { get; set; } = null!;

        [Required, MaxLength(100)]
        public string City { get; set; } = null!;

        [Required, MaxLength(20)]
        public string PostalCode { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Country { get; set; } = "Egypt";

        [MaxLength(500)]
        public string? DeliveryNotes { get; set; }


        // Navigation Property with the User

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;


        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
