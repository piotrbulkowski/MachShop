using Autofac;
using MachShop.Products.Common.Configuration;
using MachShop.Products.Common.Modules;
using MachShop.Products.Domain.BuildingBlocks;
using MachShop.Shared;

namespace MachShop.Products.Common
{
    public class ProductsStartup
    {
        private static IContainer _container;

        public static void Bootstrap(IDatabaseSettings dbSettings)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DatabaseModule(dbSettings));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterInstance(AutoMapperConfig.Initialize());

            //containerBuilder.RegisterType<IEventBus>().As<>()

            _container = containerBuilder.Build();
            ProductsCompositionRoot.Container = _container;
        }
    }
}