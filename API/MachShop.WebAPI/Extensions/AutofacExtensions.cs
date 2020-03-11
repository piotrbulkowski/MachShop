using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MachShop.Products.Common;
using MachShop.Users.Common;
using MachShop.WebAPI.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachShop.WebAPI.Extensions
{
    internal static class AutofacExtensions
    {
        internal static IServiceProvider AddAutofacProvider(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("localDb");
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new ProductsAutofacModule());
            containerBuilder.RegisterModule(new UsersAutofacModule());

            var container = containerBuilder.Build();

            UsersStartup.Bootstrap(connectionString);
            ProductsStartup.Bootstrap(connectionString);

            return new AutofacServiceProvider(container);
        }
    }
}