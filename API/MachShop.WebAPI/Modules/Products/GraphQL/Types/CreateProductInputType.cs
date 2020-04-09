using GraphQL.Types;
using MachShop.Products.Domain.Models;

namespace MachShop.WebAPI.Modules.Products.GraphQL.Types
{
    public class CreateProductInputType : InputObjectGraphType<Product>
    {
        public CreateProductInputType()
        {
            Name = "CreateProductInput";
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.Price);
            Field(x => x.Stock);
            Field(x => x.PictureFileName);
            Field(x => x.PictureUri);
        }
    }
}
