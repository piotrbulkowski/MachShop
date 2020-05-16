using System;

namespace MachShop.Products.Domain.BuildingBlocks
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
