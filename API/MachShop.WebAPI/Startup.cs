using Autofac;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using MachShop.Products.Common;
using MachShop.Shared;
using MachShop.Users.Common;
using MachShop.WebAPI.Configuration;
using MachShop.WebAPI.GraphQL;
using MachShop.WebAPI.GraphQL.Configuration;
using MachShop.WebAPI.Modules.Products;
using MachShop.WebAPI.Modules.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MachShop.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
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
            else if(DatabaseSettings.UseOracle)
                DatabaseSettings.ConnectionString =
                    Configuration.GetSection(nameof(DatabaseSettings)).GetConnectionString("OracleDb");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(o => o.AllowSynchronousIO = true);
            services.AddCors(options => options.AddPolicy("AllowAllCORS", builder
                => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
            services.AddGraphQL(x
                => x.ExposeExceptions = !Environment.IsDevelopment()); // true only in dev mode

            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            var databaseSettings = 

            containerBuilder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

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

            containerBuilder.RegisterType<MachShopCompositeQuery>().AsSelf();
            containerBuilder.RegisterType<MachShopCompositeMutation>().AsSelf();
            containerBuilder.Register(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                var dependencyResolver = new FuncDependencyResolver(type => cc.Resolve(type));
                return new MachShopSchema(dependencyResolver);
            }).AsSelf().AsImplementedInterfaces().SingleInstance();
        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseCors("AllowAllCORS");

            app.UseGraphQL<MachShopSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/playground",
                GraphQLEndPoint = "/graphql"
            });

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