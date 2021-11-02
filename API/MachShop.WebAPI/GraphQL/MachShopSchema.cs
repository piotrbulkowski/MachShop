using System;
using GraphQL.Types;

namespace MachShop.WebAPI.GraphQL
{
    public class MachShopSchema : Schema
    {
        public MachShopSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = (IObjectGraphType)serviceProvider.GetService(typeof(MachShopCompositeQuery)) ?? throw new InvalidOperationException();
            Mutation = (IObjectGraphType)serviceProvider.GetService(typeof(MachShopCompositeMutation));
        }
    }
}