using Microsoft.EntityFrameworkCore;
using ProductData.Model.ModelConfigurations;

namespace ProductData.Model
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfiguration(new ProductConfiguration());

        public DbSet<Product> Products { get; set; }
    }
}