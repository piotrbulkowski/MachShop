using MachShop.Products.Domain.BuildingBlocks;
using MachShop.Products.Domain.Enums;
using MachShop.Products.Domain.ValueObjects;

namespace MachShop.Products.Domain.Entities
{
    public class Product : IAggregateRoot
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get;  }
        public Price Price { get; }
        public int Stock { get; }

        private Product(int id, string name, string description, Price price, int stock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
        }
        public static Product Create(int id, string name, string description, CurrencyEnum currency, double priceAmount, int stock)
            => new Product(id, name, description, Price.Create(currency, priceAmount), stock);
    }
}
