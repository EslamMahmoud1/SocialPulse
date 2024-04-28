using SocialPulse.Core.Models;

namespace SocialPulse.Core.Interfaces
{
    public interface IGenericRepository<TEntity ,TKey> where TEntity : BaseEntity<TKey>
    {
        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity?> GetByIdAsync(TKey id);

        public Task AddAsync(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);
    }
}
