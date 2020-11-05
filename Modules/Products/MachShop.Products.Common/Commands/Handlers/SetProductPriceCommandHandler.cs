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
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _eventBus;

        public SetProductPriceCommandHandler(IProductRepository productRepository, IEventBus eventBus)
        {
            _productRepository = productRepository;
            _eventBus = eventBus;
        }
        public async Task<Unit> Handle(SetProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            //product.SetPrice(request.Price);

            //_eventBus.RaiseEvent(new )
            return default;
        }
    }
}
