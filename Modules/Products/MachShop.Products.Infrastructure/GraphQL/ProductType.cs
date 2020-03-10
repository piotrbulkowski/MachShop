using GraphQL.Types;
using MachShop.Products.Domain.Models;

namespace MachShop.Products.Domain.GraphQL
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.PictureUri);
            Field(p => p.Price);
            Field(p => p.Description);
            Field(p => p.Stock);
            Field(p => p.PictureFileName);
        }
    }
}
