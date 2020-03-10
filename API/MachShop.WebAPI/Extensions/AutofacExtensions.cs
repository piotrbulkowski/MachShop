using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MachShop.WebAPI.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace MachShop.WebAPI.Extensions
{
    internal static class AutofacExtensions
    {
        internal static IServiceProvider AddAutofacProvider(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new ProductsAutofacModule());

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}