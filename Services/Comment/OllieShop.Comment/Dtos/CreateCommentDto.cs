using System.ComponentModel.DataAnnotations;

namespace OllieShop.Comment.Dtos
{
    public class CreateCommentDto
    {
        [Required]
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string? UseImageUrl { get; set; }
        public string? Email { get; set; }

        [Required]
        public int ProductId { get; set; }
        public int Rate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
