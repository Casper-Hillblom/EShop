using EShop.Models;
using EShop.Models.Order;
using EShop.Models.User;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> AddPrdouctToOrderAsync(OrderListRequest request)
        {
            if (await _context.Orders.AnyAsync(x => x.Id == request.OrderId))
            {
                var item = await _context.Products.FirstOrDefaultAsync(x => x.Name == request.ProductName);

                if (item != null)
                {
                    var orderList = new OrderList()
                    {
                        OrderId = request.OrderId,
                        ProductName = request.ProductName,
                        Quantity = request.Quantity,
                        ProductNumber = item.ArticleNumber
                    };

                    _context.Items.Add(orderList);
                    await _context.SaveChangesAsync();

                    await GetOrderAsync(request.OrderId); //Får se hur detta blir
                }
            }
            return null!;
        }

        public async Task<Order> CreateOrderAsync(OrderRequest request)
        {
            if (!await _context.Users.AnyAsync(x => x.Email == request.UserEmail))
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.UserEmail);

                var orderEntity = new OrderEntity()
                {
                    Status = request.Status,
                    UserId = user.Id,
                };

                _context.Orders.Add(orderEntity);
                await _context.SaveChangesAsync();

                return new Order
                {
                    Id = orderEntity.Id,
                    Date = orderEntity.Date,
                    Status = orderEntity.Status,
                    UserEmail = request.UserEmail,
                };
            }
            return null!;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(x => x.OrderList).ToListAsync();
        }

        public async Task<OrderEntity> GetOrderAsync(int id)
        {
            return await _context.Orders.Include(x => x.OrderList).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> UpdateOrderAsync(int id, OrderRequest request)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity != null)
            {
                if (await _context.Users.AnyAsync(x => x.Email == request.UserEmail))
                {
                    orderEntity.Status = request.Status;
                    orderEntity.UserId = (await _context.Users.FirstOrDefaultAsync(x => x.Email == request.UserEmail)).Id;

                    _context.Entry(orderEntity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new Order
                    {
                        Id = orderEntity.Id,
                        Status = orderEntity.Status,
                        Date = orderEntity.Date,
                        UserEmail = request.UserEmail,
                    };
                }
            }
            return null!;
        }
    }
}
