using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MachShop.Products.Infrastructure.Repositories;
using MachShop.Shared.Commands;
using MediatR;

namespace MachShop.Products.Common.Commands.Handlers
{
    internal class SetProductPriceCommandHandler : ICommandHandler<SetProductPriceCommand>
    {
        private readonly IProductsRepository _productsRepository;

        public SetProductPriceCommandHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;
        public async Task<Unit> Handle(SetProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = _productsRepository.GetByIdAsync(request.Id);
            return default;
        }
    }
}
