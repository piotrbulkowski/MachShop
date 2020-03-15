using MediatR;

namespace MachShop.WebAPI.BuildingBlocks.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        int Id { get; }
    }

    public interface ICommand : IRequest
    {
        int Id { get; }
    }
}
