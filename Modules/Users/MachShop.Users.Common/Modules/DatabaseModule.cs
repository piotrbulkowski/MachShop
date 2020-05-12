using Autofac;
using MachShop.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Users.Common.Modules
{
    internal class DatabaseModule : Module
    {
        private readonly string _connectionString;

        public DatabaseModule(string connectionString)
            => _connectionString = connectionString;

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(db =>
                {
                    var dbContextOptions = new DbContextOptionsBuilder<UsersContext>();
                    dbContextOptions.UseSqlServer(_connectionString);

                    return new UsersContext(dbContextOptions.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
