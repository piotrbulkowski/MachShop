using System.Threading.Tasks;
using Autofac;
using MachShop.Shared.Queries;
using MediatR;

namespace MachShop.Users.Common.Processing
{
    internal static class QueryExecutor
    {
        internal static async Task<TResult> Execute<TResult>(IQuery<TResult> query)
        {
            using (var scope = UsersCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
