using System.ComponentModel.DataAnnotations;

namespace OllieShop.Catalog.Dtos.ProductImageDtos
{
    public class CreateProductImageDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "You must provide at least 4 images.")]
        [MaxLength(10, ErrorMessage = "You can provide a maximum of 10 images.")]
        public List<string> Images { get; set; } = new List<string>();
        public string? ProductId { get; set; }
    }
}
