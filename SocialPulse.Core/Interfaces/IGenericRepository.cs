using SocialPulse.Core.Models;

namespace SocialPulse.Core.Interfaces
{
    public interface IGenericRepository<TEntity ,TKey> where TEntity : BaseEntity<TKey>
    {
        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity?> GetByIdAsync<Tkey>(Tkey id);

        public Task AddAsync(TEntity entity);

        public void UpdateAsync(TEntity entity);

        public Task DeleteAsync(TKey id);
    }
}
