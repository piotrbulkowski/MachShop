using System.Threading.Tasks;
using Autofac;
using MachShop.Shared.Commands;
using MediatR;

namespace MachShop.Users.Common.Processing
{
    internal static class CommandExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            using (var scope = UsersCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Send(command);
            }
        }
        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            using (var scope = UsersCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                return await mediator.Send(command);
            }
        }
    }
}
