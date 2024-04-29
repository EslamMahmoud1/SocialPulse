using SocialPulse.Core.Models;

namespace SocialPulse.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<TEntity, TKey>? Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        public Task<int> CompleteAsync();
    }
}
