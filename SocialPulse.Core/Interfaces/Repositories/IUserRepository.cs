using SocialPulse.Core.Interfaces.Specification;
using SocialPulse.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetWithSpecsAsync(ISpecification<User> specification);
    }
}
