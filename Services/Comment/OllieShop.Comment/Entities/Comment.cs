using System.ComponentModel.DataAnnotations;

namespace OllieShop.Comment.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? UserImageUrl { get; set; }
        public string? Email { get; set; }

        [Required]
        public string ProductId { get; set; } = null!;
        public int Rate { get; set; } 

        [Required]
        [StringLength(1000)]
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
