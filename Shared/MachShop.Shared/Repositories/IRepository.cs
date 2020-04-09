using System.Threading.Tasks;

namespace MachShop.Shared.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }
}
