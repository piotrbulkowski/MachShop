using Autofac;
using MachShop.Shared;
using MachShop.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Users.Common.Modules
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
                    var dbContextOptions = new DbContextOptionsBuilder<UsersContext>();
                    if(_dbSettings.UseMSSql)
                        dbContextOptions.UseSqlServer(_dbSettings.ConnectionString);
                    else if (_dbSettings.UseOracle)
                        dbContextOptions.UseOracle(_dbSettings.ConnectionString);
                    else if (_dbSettings.UsePostgreSql)
                        dbContextOptions.UseNpgsql(_dbSettings.ConnectionString);

                    return new UsersContext(dbContextOptions.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
