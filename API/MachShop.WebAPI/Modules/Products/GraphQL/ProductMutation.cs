using GraphQL.Types;
using MachShop.Products.Domain.Models;
using MachShop.Products.Infrastructure.Abstract;
using MachShop.WebAPI.BuildingBlocks;
using MachShop.WebAPI.Modules.Products.GraphQL.Types;
using MachShop.Products.Common.Commands;

namespace MachShop.WebAPI.Modules.Products.GraphQL
{
    public class ProductMutation : ObjectGraphType<object>, IGraphMutationMarker
    {
        private readonly IProductsModule _productsModule;
        public ProductMutation(IProductsModule productsModule)
        {
            _productsModule = productsModule;
            FieldAsync<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateProductInputType>> { Name = "input" }),
                resolve: async context =>
                {
                    var input = context.GetArgument<Product>("input");
                    await _productsModule.ExecuteCommandAsync(new CreateProductCommand(input));
                    return input;
                });
        }
    }
}
