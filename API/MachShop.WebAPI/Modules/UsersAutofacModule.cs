using Autofac;
using MachShop.Users.Infrastructure;
using MachShop.Users.Infrastructure.Abstract;

namespace MachShop.WebAPI.Modules
{
    public class UsersAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<UsersModule>()
                .As<IUsersModule>()
                .InstancePerLifetimeScope();
        }
    }
}
