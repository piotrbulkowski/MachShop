using Autofac;
using MachShop.Products.Common.Configuration;
using MachShop.Products.Common.Modules;

namespace MachShop.Products.Common
{
    public class ProductsStartup
    {
        private static IContainer _container;

        public static void Bootstrap(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DatabaseModule(connectionString));
            containerBuilder.RegisterInstance(AutoMapperConfig.Initialize());

            _container = containerBuilder.Build();
            ProductsCompositionRoot.Container = _container;
        }
    }
}