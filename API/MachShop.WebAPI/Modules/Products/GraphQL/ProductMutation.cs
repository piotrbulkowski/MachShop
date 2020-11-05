using GraphQL;
using GraphQL.Types;
using MachShop.WebAPI.Modules.Products.GraphQL.Types;
using MachShop.Products.Common.Commands;
using MachShop.Products.Domain.Entities;
using MachShop.Products.Infrastructure;
using MachShop.WebAPI.GraphQL.Configuration;

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
