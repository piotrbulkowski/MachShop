using GraphQL.Types;
using MachShop.Products.Common.Queries;
using MachShop.Products.Infrastructure.Abstract;
using System.Collections.Generic;
using MachShop.WebAPI.GraphQL.Configuration;

namespace MachShop.WebAPI.Modules.Products.GraphQL
{
    public class ProductQuery : ObjectGraphType, IGraphQueryMarker
    {
        private readonly IProductsModule _productsModule;
        public ProductQuery(IProductsModule productsModule)
        {
            _productsModule = productsModule;

            FieldAsync<ListGraphType<ProductType>>("products",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name="id"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name="name"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name="description"
                    },
                    new QueryArgument<DecimalGraphType>
                    {
                        Name="price"
                    },
                    new QueryArgument<DecimalGraphType>
                    {
                        Name="stock"
                    }
                }),
                resolve: async context =>
                {
                    var products = await _productsModule.ExecuteQueryAsync(new GetAllProductsQuery());
                    return products;
                });
        }
    }
}
