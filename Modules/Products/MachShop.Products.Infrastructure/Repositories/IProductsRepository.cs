using System.Collections.Generic;
using System.Threading.Tasks;
using MachShop.Products.Domain.Product;
using MachShop.Shared.Repositories;

namespace MachShop.Products.Infrastructure.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
    }
}
