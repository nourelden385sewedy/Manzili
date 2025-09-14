using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class ServiceImage
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(500)]
        [Display(Name = "Image Path / URL")]
        public string ImagePath { get; set; } = null!; // or URL


        // Navigation Property with the Service that Image belong to

        [Required]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; } = null!;


        // Audit
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

