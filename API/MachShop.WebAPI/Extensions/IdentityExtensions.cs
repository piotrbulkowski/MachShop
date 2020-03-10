using Microsoft.Extensions.DependencyInjection;

namespace MachShop.WebAPI.Extensions
{
    internal static class IdentityExtensions
    {
        internal static IServiceCollection AddIdentityServer(this IServiceCollection services)
        {
            return services.AddIdentityServer();
        }
    }
}