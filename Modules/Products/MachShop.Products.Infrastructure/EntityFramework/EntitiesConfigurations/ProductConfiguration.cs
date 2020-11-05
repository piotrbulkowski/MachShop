using MachShop.Products.Infrastructure.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MachShop.Products.Infrastructure.EntityFramework.EntitiesConfigurations
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder
                .HasKey(k => k.Id);
        }
    }
}