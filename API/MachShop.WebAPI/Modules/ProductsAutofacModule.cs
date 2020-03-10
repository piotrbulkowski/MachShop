using Autofac;
using MachShop.Products.Infrastructure;
using MachShop.Products.Infrastructure.Abstract;

namespace MachShop.WebAPI.Modules
{
    public class ProductsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<ProductsModule>()
                .As<IProductsModule>()
                .InstancePerLifetimeScope();
        }
    }
}