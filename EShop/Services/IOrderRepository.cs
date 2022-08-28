using EShop.Models.Order;
using EShop.Models.Product;

namespace EShop.Services
{
    public interface IOrderRepository
    {
        public Task<Order> AddPrdouctToOrderAsync(OrderListRequest request);
        public Task<Order> CreateOrderAsync(OrderRequest request);
        public Task<OrderEntity> GetOrderAsync(int id);
        public Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
        public Task<Order> UpdateOrderAsync(int id, OrderRequest request);
        public Task<bool> DeleteOrderAsync(int id);
    }
}
