using MachShop.Products.Domain.Enums;
using MachShop.Products.Infrastructure.EntityFramework.Entities;

namespace MachShop.Products.Infrastructure.Mappings
{
    internal static class ProductMappings
    {
        public static Product AsDbEntity(this Domain.Entities.Product product)
        {
            if (product is null)
            {
                return null;
            }

            var dbEntity = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PriceCurrency = (int)product.Price.Currency,
                PriceAmount = product.Price.Amount,
                Stock = product.Stock
            };
            return dbEntity;
        }

        public static Domain.Entities.Product AsDomainEntity(this Product productEntity)
        {
            if (productEntity is null)
            {
                return null;
            }

            var domainEntity = Domain.Entities.Product.Create(
                productEntity.Id, productEntity.Name, productEntity.Description,
                (CurrencyEnum) productEntity.PriceCurrency, productEntity.PriceAmount, productEntity.Stock);
            return domainEntity;
        }
    }
}