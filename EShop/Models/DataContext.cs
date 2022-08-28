using EShop.Models.Order;
using EShop.Models.Product;
using EShop.Models.User;
using Microsoft.EntityFrameworkCore;

namespace EShop.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
        public virtual DbSet<CategoryEntity> Categories { get; set; } = null!;
    }
}
