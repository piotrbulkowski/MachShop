using MachShop.Shared.Commands;

namespace MachShop.Products.Common.Commands
{
    public class SetProductPriceCommand : ICommand
    {
        public int Id { get; }
        public decimal Price { get; }

        public SetProductPriceCommand(int id, decimal price)
        {
            Id = id;
            Price = price;
        }
    }
}
