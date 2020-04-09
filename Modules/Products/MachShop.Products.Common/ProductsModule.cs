using System.Threading.Tasks;
using MachShop.Products.Common.Processing;
using MachShop.Products.Infrastructure.Abstract;
using MachShop.Shared.Commands;
using MachShop.Shared.Queries;

namespace MachShop.Products.Common
{
    public class ProductsModule : IProductsModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
            => await CommandExecutor.Execute(command);

        public async Task ExecuteCommandAsync(ICommand command)
            => await CommandExecutor.Execute(command);

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
            => await QueryExecutor.Execute(query);
    }
}
