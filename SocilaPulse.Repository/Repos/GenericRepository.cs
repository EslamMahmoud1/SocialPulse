using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.Interfaces;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Data.Context;

namespace SocialPulse.Repository.Repos
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly SocialPulseDataContext _context;

        public GenericRepository(SocialPulseDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            if(entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync<Tkey>(Tkey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
