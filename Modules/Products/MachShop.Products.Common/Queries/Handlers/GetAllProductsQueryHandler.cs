using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MachShop.Products.Common.DTO;
using MachShop.Products.Infrastructure.Repositories;
using MachShop.Shared.Queries;
using MediatR;

namespace MachShop.Products.Common.Queries.Handlers
{
    internal class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _repository;
        public GetAllProductsQueryHandler(IMapper mapper, IProductsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        async Task<IEnumerable<ProductDto>> IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>.Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
