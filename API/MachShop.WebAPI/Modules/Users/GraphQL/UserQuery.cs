using GraphQL.Types;
using MachShop.Users.Common.Queries;
using MachShop.Users.Infrastructure.Abstract;
using System.Collections.Generic;
using MachShop.WebAPI.GraphQL.Configuration;

namespace MachShop.WebAPI.Modules.Users.GraphQL
{
    public class UserQuery : ObjectGraphType, IGraphQueryMarker
    {
        public UserQuery(IUsersModule usersModule)
        {
            FieldAsync<ListGraphType<UserType>>("users",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name="id"
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name="isActive"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name="username"
                    }
                }),
                resolve: async context =>
                {
                    var products = await usersModule.ExecuteQueryAsync(new GetAllUsersQuery());
                    return products;
                });
        }
    }
}
