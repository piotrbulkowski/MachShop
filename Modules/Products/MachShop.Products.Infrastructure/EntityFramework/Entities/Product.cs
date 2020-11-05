namespace MachShop.Products.Infrastructure.EntityFramework.Entities
{
    public class Product
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceCurrency { get; set; }
        public double PriceAmount { get; set; }
        public int Stock { get; set; }
    }
}