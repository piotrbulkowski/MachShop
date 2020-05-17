using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachShop.Products.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Products.Infrastructure.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _productsContext;
        public ProductsRepository(ProductsContext productsContext)
            => _productsContext = productsContext;
        public async Task AddAsync(Product entity)
            => await _productsContext.Products.AddAsync(entity);

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _productsContext.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id)
            => await _productsContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        public void Remove(Product entity)
            => _productsContext.Products.Remove(entity);
    }
}
