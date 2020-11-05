using System.Collections.Generic;
using System.Threading.Tasks;
using MachShop.Products.Domain.Entities;

namespace MachShop.Products.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
