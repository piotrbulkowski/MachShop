using System;
using GraphQL;
using GraphQL.Types;

namespace MachShop.WebAPI.GraphQL
{
    public class MachShopSchema : Schema
    {
        public MachShopSchema(IServiceProvider  serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetService(typeof(MachShopCompositeQuery)).As<IObjectGraphType>();
            Mutation = serviceProvider.GetService(typeof(MachShopCompositeMutation)).As<IObjectGraphType>();
        }
    }
}