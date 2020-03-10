using GraphQL;
using GraphQL.Types;

namespace MachShop.WebAPI.GraphQL
{
    public class MachShopSchema : Schema
    {
        public MachShopSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MachShopCompositeQuery>();
        }
    }
}