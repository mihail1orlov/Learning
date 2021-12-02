using Microsoft.EntityFrameworkCore;

namespace ProductApi.Model
{
    public class ProductApiContext : DbContext
    {
        public ProductApiContext(DbContextOptions<ProductApiContext> options) : base(options) { }

        public DbSet<Product> MyProperty { get; set; }
    }
}