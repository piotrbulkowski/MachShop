using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MachShop.Products.Domain.BuildingBlocks;
using MachShop.Products.Infrastructure.Repositories;
using MachShop.Shared.Commands;
using MediatR;

namespace MachShop.Products.Common.Commands.Handlers
{
    internal class SetProductPriceCommandHandler : ICommandHandler<SetProductPriceCommand>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IEventBus _eventBus;

        public SetProductPriceCommandHandler(IProductsRepository productsRepository, IEventBus eventBus)
        {
            _productsRepository = productsRepository;
            _eventBus = eventBus;
        }
        public async Task<Unit> Handle(SetProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await _productsRepository.GetByIdAsync(request.Id);

            product.SetPrice(request.Price);

            return default;
        }
    }
}
