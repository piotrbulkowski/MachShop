using System.Threading.Tasks;
using MachShop.Shared.Commands;
using MachShop.Shared.Queries;
using MachShop.Users.Infrastructure.Abstract;

namespace MachShop.Users.Common
{
    public class UsersModule : IUsersModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            throw new System.NotImplementedException();
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            throw new System.NotImplementedException();
        }
    }
}
