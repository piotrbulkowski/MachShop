using Autofac;
using MachShop.Products.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Products.Common.Modules
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
                    var dbContextOptions = new DbContextOptionsBuilder<ProductsContext>();
                    dbContextOptions.UseSqlServer(_connectionString);

                    return new ProductsContext(dbContextOptions.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
