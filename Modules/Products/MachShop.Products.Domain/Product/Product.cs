using MachShop.Products.Domain.BuildingBlocks;
using MachShop.Shared.Exceptions;

namespace MachShop.Products.Domain.Product
{
    public class Product : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }

        public void SetPrice(decimal price)
        {
            if(price < 0)
                throw new ValidationException("Product price cannot be set to less than 0!");

            Price = price;
        }
    }
}
