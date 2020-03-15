using System;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using MachShop.WebAPI.Extensions;
using MachShop.WebAPI.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MachShop.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IServiceProvider ConfigureServices(IServiceCollection services, IHostEnvironment env)
        {
            services.AddCors(options => options.AddPolicy("AllowAllCORS", builder
                => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
            // GraphQL
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService))
                .AddScoped<MachShopSchema>();
            services.AddGraphQL(x
                    => x.ExposeExceptions = !env.IsDevelopment()) // true only in dev mode
                .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddMvc();
            return AutofacExtensions.AddAutofacProvider(services, Configuration);
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

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}