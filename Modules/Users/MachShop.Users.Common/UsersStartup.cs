using Autofac;
using MachShop.Users.Common.Modules;

namespace MachShop.Users.Common
{
    public class UsersStartup
    {
        private static IContainer _container;

        public static void Bootstrap(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new DatabaseModule(connectionString));

            _container = containerBuilder.Build();
            UsersCompositionRoot.Container = _container;
        }
    }
}
