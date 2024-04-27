using SocialPulse.Core.Interfaces;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Data.Context;
using System.Collections;

namespace SocialPulse.Repository.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialPulseDataContext _context;

        //hashtable to store created repositories by unit of work to efficiently work with repositories
        private readonly Hashtable _repositories;
        public UnitOfWork(SocialPulseDataContext context, Hashtable repositories)
        {
            _context = context;
            _repositories = repositories;
        }

        public IGenericRepository<TEntity, TKey>? Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var TEntityName = typeof(TEntity).Name;

            //checks on repositories hashtable if this requiered repo already exists

            if (_repositories.ContainsKey(TEntityName))
                return _repositories[TEntityName] as GenericRepository<TEntity, TKey>;

            //if not create new repo , add to hashtable then return

            var CreatedRepository = new GenericRepository<TEntity, TKey>(_context);
            _repositories.Add(TEntityName, CreatedRepository);
            return CreatedRepository;
        }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }


    }
}
