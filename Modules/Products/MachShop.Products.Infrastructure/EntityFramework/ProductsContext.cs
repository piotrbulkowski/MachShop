using MachShop.Products.Infrastructure.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Product = MachShop.Products.Infrastructure.EntityFramework.Entities.Product;

namespace MachShop.Products.Infrastructure.EntityFramework
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
