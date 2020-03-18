using Autofac;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using MachShop.Products.Common;
using MachShop.Users.Common;
using MachShop.WebAPI.GraphQL;
using MachShop.WebAPI.Modules;
using MachShop.WebAPI.Modules.Products;
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

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
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
            var connectionString = Configuration.GetConnectionString("localDb");

            containerBuilder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            containerBuilder.RegisterModule(new ProductsAutofacModule());
            containerBuilder.RegisterModule(new UsersAutofacModule());

            UsersStartup.Bootstrap(connectionString);
            ProductsStartup.Bootstrap(connectionString);

            // GraphQL
            containerBuilder.RegisterType<MachShopCompositeQuery>().AsSelf();
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