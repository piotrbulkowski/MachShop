using GraphQL.Types;
using MachShop.Products.Domain.Entities;

namespace MachShop.WebAPI.Modules.Products.GraphQL.Types
{
    public sealed class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";

            Field(p => p.Id).Description("Product id.");
            Field(p => p.Name).Description("Product name.");
            Field(p => p.Description).Description("Product description");
            //Field(p => p.Price)
            //    .Description("Product price.");
            Field(p => p.Stock).Description("Amount of available units of product.");
        }
    }
}
