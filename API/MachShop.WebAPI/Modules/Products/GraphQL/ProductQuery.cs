using GraphQL.Types;
using MachShop.Products.Domain.Models;
using MachShop.WebAPI.BuildingBlocks.Abstract;

namespace MachShop.WebAPI.Modules.Products.GraphQL
{
    public class ProductQuery : ObjectGraphType<object>, IGraphQueryMarker
    {
        public ProductQuery()
        {
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the product" }
                ),
                resolve: context => new Product
                {
                    Id = 0,
                    Name = "testName",
                    Description = "testDescription",
                    PictureFileName = "testimg",
                    Price = 250,
                    Stock = 10,
                    PictureUri = "/imgs/it/is/a/test/testimg.png"
                }
            );
        }
    }
}
