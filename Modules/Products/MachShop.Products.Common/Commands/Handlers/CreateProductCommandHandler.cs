using MachShop.Products.Infrastructure.Repositories;
using MachShop.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MachShop.Products.Common.Commands.Handlers
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductsRepository _productsRepository;
        public CreateProductCommandHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productsRepository.AddAsync(request.Product);
            return default;
        }
    }
}
