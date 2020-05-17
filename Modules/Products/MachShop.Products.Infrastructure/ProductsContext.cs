using System;
using MachShop.Products.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Products.Infrastructure
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options) { }
        #region Entities
        internal DbSet<Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
