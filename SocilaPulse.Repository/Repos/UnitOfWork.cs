using SocialPulse.Core.Interfaces.Repositories;
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
        public UnitOfWork(SocialPulseDataContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
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

        public IUserRepository UserRepository()
        {
            var TEntityName = typeof(User).Name;

            if (_repositories.ContainsKey(TEntityName))
                return _repositories[TEntityName] as UserRepository;

            var CreatedRepository = new UserRepository(_context);
            _repositories.Add(TEntityName, CreatedRepository);
            return CreatedRepository;
        }

        public IFriendRepository FriendRepository()
        {
            var TEntityName = typeof(Friend).Name;

            if (_repositories.ContainsKey(TEntityName))
                return _repositories[TEntityName] as FriendRepository;

            var CreatedRepository = new FriendRepository(_context);
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
