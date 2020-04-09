using Autofac;
using MachShop.Shared.Commands;
using MediatR;
using System.Threading.Tasks;

namespace MachShop.Products.Common.Processing
{
    internal static class CommandExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            using (var scope = ProductsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }
        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = ProductsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
