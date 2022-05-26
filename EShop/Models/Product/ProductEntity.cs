using System.ComponentModel.DataAnnotations;

namespace EShop.Models.Product
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;
    }
}
