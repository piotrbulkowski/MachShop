using System;

namespace MachShop.Products.Domain.BuildingBlocks
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        public DomainEvent()
            => OccurredOn = DateTime.UtcNow;
    }
}
