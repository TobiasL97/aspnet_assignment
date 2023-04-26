using aspnet_assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnet_assignment.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<StockEntity> Stocks { get; set; } = null!;
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; } = null!;
        public DbSet<ProductImageEntity> ProductImages { get; set; } = null!;
    }
}
