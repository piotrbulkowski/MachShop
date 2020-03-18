using System.Reflection;
using Autofac;
using MachShop.Products.Infrastructure;
using MachShop.Products.Infrastructure.Abstract;
using MachShop.WebAPI.BuildingBlocks.Abstract;
using MachShop.WebAPI.Modules.Products.GraphQL;
using Module = Autofac.Module;

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
            containerBuilder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<IGraphQueryMarker>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}