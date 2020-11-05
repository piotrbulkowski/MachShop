using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachShop.Products.Domain.Entities;
using MachShop.Products.Infrastructure.EntityFramework;
using MachShop.Products.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MachShop.Products.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _context;
        public ProductRepository(ProductsContext productsContext)
            => _context = productsContext;

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity.AsDbEntity());
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.AsNoTracking()
                .Select(p => p.AsDomainEntity())
                .ToListAsync();


        public async Task<Product> GetByIdAsync(int id)
        {
            var dbEntity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return dbEntity.AsDomainEntity();
        }

        public async Task UpdateAsync(Product product)
        {
            var productEntity = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            productEntity.Description = product.Description;
            productEntity.Name = product.Name;
            productEntity.PriceAmount = product.Price.Amount;
            productEntity.PriceCurrency = (int)product.Price.Currency;
            productEntity.Stock = product.Stock;
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product.AsDbEntity());
            await _context.SaveChangesAsync();
        }


    }
}
