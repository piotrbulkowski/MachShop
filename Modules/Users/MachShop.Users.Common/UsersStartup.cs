using Autofac;
using MachShop.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Users.Common
{
    public class UsersStartup
    {
        private readonly IContainer container;

        public static void Bootstrap(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(db =>
            {
                var dbContextOptions = new DbContextOptionsBuilder<UsersContext>();
                dbContextOptions.UseSqlServer(connectionString);

                return new UsersContext(dbContextOptions.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
        }
    }
}
