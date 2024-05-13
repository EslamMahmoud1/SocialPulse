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
    public class UserRepository : IUserRepository
    {
        private readonly SocialPulseDataContext _context;

        public UserRepository(SocialPulseDataContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id) =>  (await _context.Set<User>().FindAsync(id))!;
        

        public async Task<User> GetWithSpecsAsync(ISpecification<User> specification)
            => (await SpecificationEvaluator<User, string>.BuildQuery(_context.Set<User>(), specification).FirstOrDefaultAsync())!;
     
    }
}
