using Autofac;
using MachShop.Users.Common;
using MachShop.Users.Infrastructure.Abstract;
using MachShop.WebAPI.Modules.Users.GraphQL;

namespace MachShop.WebAPI.Modules.Users
{
    public class UsersAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<UsersModule>()
                .As<IUsersModule>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserRoleType>().AsSelf();
            containerBuilder.RegisterType<UserType>().AsSelf();
        }
    }
}
