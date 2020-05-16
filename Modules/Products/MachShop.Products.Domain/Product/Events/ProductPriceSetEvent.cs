using MachShop.Products.Domain.BuildingBlocks;

namespace MachShop.Products.Domain.Product.Events
{
    public class ProductPriceSetEvent : DomainEvent
    {
        public int ProductId { get; set; }
        public decimal NewPrice { get; set; }
        public ProductPriceSetEvent(int productId, decimal newPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
        }
    }
}
