using MachShop.Shared.Commands;
using System.Threading.Tasks;

namespace MachShop.Products.Domain.BuildingBlocks
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : ICommand;
        Task RaiseEvent<T>(T @event) where T : IDomainEvent;
    }
}
