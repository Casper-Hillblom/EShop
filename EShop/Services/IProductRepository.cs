using EShop.Models.Product;

namespace EShop.Services
{
    public interface IProductRepository
    {
        public Task<Product> CreateProductAsync(ProductRequest request);
        public Task<ProductEntity> GetProductAsync(int id);
        public Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        public Task<Product> UpdateProductAsync(int id, ProductRequest request);
        public Task<bool> DeleteProductAsync(int id);
    }
}
