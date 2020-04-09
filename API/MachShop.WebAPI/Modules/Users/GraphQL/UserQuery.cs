using GraphQL.Types;
using MachShop.Users.Common.Queries;
using MachShop.Users.Infrastructure.Abstract;
using MachShop.WebAPI.BuildingBlocks.Abstract;
using System.Collections.Generic;

namespace MachShop.WebAPI.Modules.Users.GraphQL
{
    public class UserQuery : ObjectGraphType, IGraphQueryMarker
    {
        private static IUsersModule _usersModule;
        public UserQuery(IUsersModule usersModule)
        {
            _usersModule = usersModule;
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
                    var products = await _usersModule.ExecuteQueryAsync(new GetAllUsersQuery());
                    return products;
                });
        }
    }
}
