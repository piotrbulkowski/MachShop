using MachShop.Products.Domain.Entities;
using MachShop.Shared.Commands;

namespace MachShop.Products.Common.Commands
{
    public class CreateProductCommand : ICommand
    {
        public int Id { get; }
        public Product Product { get; }
        public CreateProductCommand(Product product)
        {
            Id = product.Id;
            Product = product;
        }

    }
}
