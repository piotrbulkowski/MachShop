using Autofac;
using MachShop.Shared.Queries;
using MediatR;
using System.Threading.Tasks;

namespace MachShop.Products.Common.Processing
{
    internal static class QueryExecutor
    {
        internal static async Task<TResult> Execute<TResult>(IQuery<TResult> query)
        {
            using (var scope = ProductsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
