using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Government { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? PostalCode { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? DeliveryNotes { get; set; }

        public bool IsDefault { get; set; } = false;


        // Foreign Key & Navigation Property
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
