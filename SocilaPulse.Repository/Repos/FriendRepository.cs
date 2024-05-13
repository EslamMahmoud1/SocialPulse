using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Specification;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Data.Context;
using SocialPulse.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Repository.Repos
{
    public class FriendRepository : IFriendRepository
    {
        private readonly SocialPulseDataContext _context;

        public FriendRepository(SocialPulseDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Friend friend)
        {
            await _context.Friends.AddAsync(friend);
        }

        public async Task<IEnumerable<Friend>> GetAllAsync()
        {
          return  await _context.Friends.ToListAsync();
        }

        public async Task<IEnumerable<Friend>> GetAllWithSpecsAsync(ISpecification<Friend> specification)
        {
            return await SpecificationEvaluator<Friend, string>.BuildQuery(_context.Set<Friend>(), specification).ToListAsync();
        }

        public async Task<Friend> GetWithSpecsAsync(ISpecification<Friend> specification)
        {
            return (await SpecificationEvaluator<Friend, string>.BuildQuery(_context.Set<Friend>(), specification).FirstOrDefaultAsync())!;
        }
    }
}
