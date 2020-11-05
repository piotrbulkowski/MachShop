using Autofac;
using MachShop.Products.Common;
using MachShop.Products.Infrastructure;
using MachShop.WebAPI.Modules.Products.GraphQL;
using MachShop.WebAPI.Modules.Products.GraphQL.Types;

namespace MachShop.WebAPI.Modules.Products
{
    public class ProductsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<ProductsModule>()
                .As<IProductsModule>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<ProductType>().AsSelf();
        }
    }
}