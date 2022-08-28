using System.ComponentModel.DataAnnotations;

namespace EShop.Models.Order
{
    public class OrderList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public int ProductNumber { get; set; }

        [Required]
        public int Quantity { get; set; }

        public OrderEntity OrderEntity { get; set; } = null!;
    }
}
