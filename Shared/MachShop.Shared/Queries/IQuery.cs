using MediatR;

namespace MachShop.Shared.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}
