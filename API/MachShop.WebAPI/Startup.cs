using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Instrumentation;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using MachShop.Products.Common;
using MachShop.Shared;
using MachShop.Users.Common;
using MachShop.WebAPI.Configuration;
using MachShop.WebAPI.GraphQL;
using MachShop.WebAPI.GraphQL.Configuration;
using MachShop.WebAPI.Modules;
using MachShop.WebAPI.Modules.Products;
using MachShop.WebAPI.Modules.Users;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MachShop.WebAPI
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IHostEnvironment Environment { get; }
        private IDatabaseSettings DatabaseSettings { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            DatabaseSettings = Configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            if(DatabaseSettings.UsePostgreSql)
                DatabaseSettings.ConnectionString =
                    Configuration.GetSection(nameof(DatabaseSettings)).GetConnectionString("PostgreSqlDb");
            else if(DatabaseSettings.UseMSSql)
                DatabaseSettings.ConnectionString =
                    Configuration.GetSection(nameof(DatabaseSettings)).GetConnectionString("MSSqlDb");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(o => o.AllowSynchronousIO = true);
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

            services.AddCors(options => options.AddPolicy("AllowAllCORS", builder
                => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

            services.AddHttpContextAccessor();
            services
                .AddSingleton<ISchema, MachShopSchema>()
                .AddSingleton<MachShopCompositeQuery>()
                .AddSingleton<MachShopCompositeMutation>()
                .AddGraphQL()
                .AddGraphTypes(typeof(MachShopSchema))
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment());
                
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new ProductsAutofacModule());
            containerBuilder.RegisterModule(new UsersAutofacModule());

            UsersStartup.Bootstrap(DatabaseSettings);
            ProductsStartup.Bootstrap(DatabaseSettings);

            // GraphQL
            containerBuilder
                .RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .AssignableTo<IGraphQueryMarker>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<InstrumentFieldsMiddleware>().AsSelf();

            containerBuilder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var schema = new MachShopSchema(new FuncServiceProvider(type => context.Resolve(type)));
                return schema;
            }).AsSelf().AsImplementedInterfaces().SingleInstance();

        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseCors("AllowAllCORS");

            app.UseGraphQL<MachShopSchema>();
            app.UseGraphQLPlayground(options: new PlaygroundOptions(), path: "/playground");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Go to /playground to have fun with GraphQL :)");
                });
            });
        }
    }
}