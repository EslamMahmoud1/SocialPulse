using SocialPulse.Core.Interfaces.Specification;
using SocialPulse.Core.Models;

namespace SocialPulse.Core.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> GetWithSpecsAsync(ISpecification<TEntity> specification);

        public Task AddAsync(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);
    }
}
