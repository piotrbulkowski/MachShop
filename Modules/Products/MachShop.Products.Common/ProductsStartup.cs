using Autofac;
using MachShop.Products.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Products.Common
{
    public class ProductsStartup
    {
        private IContainer container;

        public static void Bootstrap(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(db =>
            {
                var dbContextOptions = new DbContextOptionsBuilder<ProductsContext>();
                dbContextOptions.UseSqlServer(connectionString);

                return new ProductsContext(dbContextOptions.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
        }
    }
}
