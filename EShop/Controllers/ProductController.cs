using EShop.Models.Product;
using EShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductRequest request)
        {
            var product = await _productRepository.CreateProductAsync(request);
            if (product == null)
                return BadRequest("A product with the same article-number allready exist");
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
                return NotFound("Product not found");
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productRepository.GetAllProductsAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductRequest request)
        {
            var product = await _productRepository.UpdateProductAsync(id, request);
            if (product == null)
                return NotFound("Product not found");
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productRepository.DeleteProductAsync(id))
                return Ok("Deleted product for id: " + id);
            return NotFound("Product not found");
        }
    }
}
