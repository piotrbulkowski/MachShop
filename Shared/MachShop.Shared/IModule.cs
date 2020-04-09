using MachShop.Shared.Commands;
using MachShop.Shared.Queries;
using System.Threading.Tasks;

namespace MachShop.Shared
{
    public interface IModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
