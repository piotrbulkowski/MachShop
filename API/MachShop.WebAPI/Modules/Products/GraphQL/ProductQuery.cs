using GraphQL.Types;
using MachShop.Products.Common.Queries;
using System.Collections.Generic;
using MachShop.Products.Infrastructure;
using MachShop.WebAPI.GraphQL.Configuration;
using MachShop.WebAPI.Modules.Products.GraphQL.Types;

namespace MachShop.WebAPI.Modules.Products.GraphQL
{
    public class ProductQuery : ObjectGraphType, IGraphQueryMarker
    {
        public ProductQuery(IProductsModule productsModule)
        {
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
                    var products = await productsModule.ExecuteQueryAsync(new GetAllProductsQuery());
                    return products;
                });
        }
    }
}
