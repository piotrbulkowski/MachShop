using Autofac;

namespace MachShop.Users.Common
{
    internal static class UsersCompositionRoot
    {
        public static IContainer Container { private get; set; }

        internal static ILifetimeScope BeginLifetimeScope()
            => Container.BeginLifetimeScope();
    }
}
