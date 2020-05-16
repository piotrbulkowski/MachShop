using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MachShop.Shared.Commands;
using MediatR;

namespace MachShop.Products.Domain.BuildingBlocks
{
    public sealed class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task SendCommand<T>(T command) where T : ICommand
            => await _mediator.Send(command);

        public async Task RaiseEvent<T>(T @event) where T : IDomainEvent
        {
            // TODO:Add saving to event store
            await _mediator.Publish(@event);
        }
    }
}
