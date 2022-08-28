using EShop.Models;
using EShop.Models.Product;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EShop.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Product> CreateProductAsync(ProductRequest request)
        {
            if (!await _context.Products.AnyAsync(x => x.ArticleNumber == request.ArticleNumber))
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.CategoryName);

                if (category == null)
                {
                    category = new CategoryEntity { Name = request.CategoryName };
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                }

                var productEntity = new ProductEntity()
                {
                    Name = request.Name,
                    ArticleNumber = request.ArticleNumber,
                    Description = request.Description,
                    Price = request.Price,
                    CategoryId = category.Id
                };

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();

                return new Product
                {
                    Id = productEntity.Id,
                    Name = productEntity.Name,
                    ArticleNumber=productEntity.ArticleNumber,
                    Description = productEntity.Description,
                    Price= productEntity.Price,
                    CategoryName = category.Name,
                };
            }
            return null!;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetProductAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateProductAsync(int id, ProductRequest request)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.CategoryName);

                if (category == null)
                {
                    category = new CategoryEntity { Name = request.CategoryName };
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                }

                productEntity.Name = request.Name;
                productEntity.ArticleNumber = request.ArticleNumber;
                productEntity.Description = request.Description;
                productEntity.Price = request.Price;
                productEntity.CategoryId = category.Id;

                _context.Entry(productEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new Product
                {
                    Id = productEntity.Id,
                    Name = productEntity.Name,
                    ArticleNumber = productEntity.ArticleNumber,
                    Description = productEntity.Description,
                    Price = productEntity.Price,
                    CategoryName = category.Name,
                };
            }
            return null!;
        }
    }
}
