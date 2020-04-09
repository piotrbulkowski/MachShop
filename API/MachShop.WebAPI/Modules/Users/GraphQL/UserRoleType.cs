using GraphQL.Types;
using MachShop.Users.Domain.Models;

namespace MachShop.WebAPI.Modules.Users.GraphQL
{
    public class UserRoleType : ObjectGraphType<UserRole>
    {
        public UserRoleType()
        {
            Name = "UserRole";

            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
