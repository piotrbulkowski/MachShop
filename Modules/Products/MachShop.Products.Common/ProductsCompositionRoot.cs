using Autofac;

namespace MachShop.Products.Common
{
    internal static class ProductsCompositionRoot
    {
        public static IContainer Container { private get; set; }

        internal static ILifetimeScope BeginLifetimeScope()
            => Container.BeginLifetimeScope();
    }
}
