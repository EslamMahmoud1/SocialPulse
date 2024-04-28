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

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
