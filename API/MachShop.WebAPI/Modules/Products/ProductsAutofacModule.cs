using Autofac;
using MachShop.Products.Common;
using MachShop.Products.Infrastructure.Abstract;
using MachShop.WebAPI.Modules.Products.GraphQL;

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

            containerBuilder.RegisterModule(new MediatorModule());
        }
    }
}