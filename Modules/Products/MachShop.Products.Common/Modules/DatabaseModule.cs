using Autofac;
using MachShop.Products.Infrastructure;
using MachShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Products.Common.Modules
{
    internal class DatabaseModule : Module
    {
        private readonly IDatabaseSettings _dbSettings;

        public DatabaseModule(IDatabaseSettings dbSettings)
            => _dbSettings = dbSettings;

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(db =>
                {
                    var dbContextOptions = new DbContextOptionsBuilder<ProductsContext>();
                    if(_dbSettings.UseMSSql)
                        dbContextOptions.UseSqlServer(_dbSettings.ConnectionString);
                    else if (_dbSettings.UseOracle)
                        dbContextOptions.UseOracle(_dbSettings.ConnectionString);
                    else if (_dbSettings.UsePostgreSql)
                        dbContextOptions.UseNpgsql(_dbSettings.ConnectionString);

                    return new ProductsContext(dbContextOptions.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
