using GraphQL.Types;
using MachShop.Users.Domain.Models;

namespace MachShop.WebAPI.Modules.Users.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";

            Field(x => x.Id).Description("User id");
            Field(x => x.IsActive).Description("Is user active");
            Field(x => x.Username);
            Field(x => x.Password).Description("User password");
            Field<ListGraphType<UserRoleType>>("UserRoles", resolve: context => context.Source.Roles);
        }
    }
}
