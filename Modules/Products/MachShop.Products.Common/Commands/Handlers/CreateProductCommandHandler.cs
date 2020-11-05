using MachShop.Products.Infrastructure.Repositories;
using MachShop.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MachShop.Products.Common.Commands.Handlers
{
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
            => _productRepository = productRepository;
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(request.Product);
            return default;
        }
    }
}
