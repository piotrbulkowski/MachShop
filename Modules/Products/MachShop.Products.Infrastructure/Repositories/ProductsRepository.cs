using MachShop.Products.Domain.Models;
using System.Threading.Tasks;

namespace MachShop.Products.Infrastructure.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _productsContext;
        public ProductsRepository(ProductsContext productsContext)
            => _productsContext = productsContext;
        public async Task AddAsync(Product entity)
            => await _productsContext.Products.AddAsync(entity);

        public void Remove(Product entity)
            => _productsContext.Products.Remove(entity);
    }
}
