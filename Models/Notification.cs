using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required, MaxLength(1000)]
        public string Message { get; set; } = null!;

        public bool IsRead { get; set; } = false;


        // Navigation Property with User

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;


        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
