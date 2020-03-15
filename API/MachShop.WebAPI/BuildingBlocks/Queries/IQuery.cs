using MediatR;

namespace MachShop.WebAPI.BuildingBlocks.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}
