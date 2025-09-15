using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manzili.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(3000)]
        public string Comment { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; }


        // Navigation Property with the Service

        [Required]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; } = null!;


        // Navigation Property with the User who left the Review

        public int? UserId { get; set; }   // The buyer who left the review

        [ForeignKey("UserId")]
        public User? Reviewer { get; set; } = null!;


        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

/* Future thing

        // For replies: link to parent review
        public int? ParentReviewId { get; set; } // null = original buyer review, not a reply
        [ForeignKey("ParentReviewId")]
        public Review? ParentReview { get; set; }


        // Convenience property (not mapped)
        [NotMapped]
        public bool IsReply => ParentReviewId != null;
 
*/
