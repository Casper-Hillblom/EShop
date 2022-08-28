using System.ComponentModel.DataAnnotations;

namespace EShop.Models.Order
{
    public class OrderListRequest
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
