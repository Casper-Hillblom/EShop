using EShop.Models.Order;
using EShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("{AddItemToOrder}")]
        public async Task<IActionResult> AddItemToOrder(OrderListRequest request)
        {
            var item = await _orderRepository.AddPrdouctToOrderAsync(request);
            if (item == null)
                return BadRequest("No order exist for this Id");
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest request)
        {
            var order = await _orderRepository.CreateOrderAsync(request);
            if (order == null)
                return BadRequest("Need an existing email to create a order");
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id);
            if (order == null)
                return NotFound("Order not found");
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderRepository.GetAllOrdersAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, OrderRequest request)
        {
            var order = await _orderRepository.UpdateOrderAsync(id, request);
            if (order == null)
                return NotFound("Id or Email does not exist or match");
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (await _orderRepository.DeleteOrderAsync(id))
                return Ok("Deleted order for id: " + id);
            return NotFound("Order not found");
        }
    }
}
