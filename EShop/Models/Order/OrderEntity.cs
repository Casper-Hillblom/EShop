using EShop.Models.Product;
using EShop.Models.User;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models.Order
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public int UserId { get; set; }

        public virtual ICollection<OrderList> OrderList { get; set; } = null!;
        //public UserEntity User { get; set; } = null!;

        //public virtual ICollection<ProductEntity> Products { get; set; } = null!;
        //Hur många av varje??
    }
}
