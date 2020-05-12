using System.Threading.Tasks;
using MachShop.Shared.Commands;
using MachShop.Shared.Queries;
using MachShop.Users.Common.Processing;
using MachShop.Users.Infrastructure.Abstract;

namespace MachShop.Users.Common
{
    public class UsersModule : IUsersModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
            => await CommandExecutor.Execute(command);

        public async Task ExecuteCommandAsync(ICommand command)
            => await CommandExecutor.Execute(command);

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
            => await QueryExecutor.Execute(query);
    }
}
