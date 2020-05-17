using Autofac;
using MachShop.Shared;
using MachShop.Users.Common.Modules;

namespace MachShop.Users.Common
{
    public class UsersStartup
    {
        private static IContainer _container;

        public static void Bootstrap(IDatabaseSettings dbSettings)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DatabaseModule(dbSettings));

            _container = containerBuilder.Build();
            UsersCompositionRoot.Container = _container;
        }
    }
}
