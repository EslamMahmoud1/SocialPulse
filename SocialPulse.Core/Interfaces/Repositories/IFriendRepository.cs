using SocialPulse.Core.Interfaces.Specification;
using SocialPulse.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Core.Interfaces.Repositories
{
    public interface IFriendRepository
    {
        Task AddAsync(Friend friend);
        Task<IEnumerable<Friend>> GetAllAsync();
        Task<IEnumerable<Friend>> GetAllWithSpecsAsync(ISpecification<Friend> specification);
        Task<List<Friend>> GetAllWithSpecsAsyncc(ISpecification<Friend> specification);
        Task<Friend> GetWithSpecsAsync(ISpecification<Friend> specification);
    }
}
