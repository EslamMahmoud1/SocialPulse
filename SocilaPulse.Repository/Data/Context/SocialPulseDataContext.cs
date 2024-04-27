using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.Models;
using System.Reflection;

namespace SocialPulse.Repository.Data.Context
{
    public class SocialPulseDataContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Friend> Friends { get; set; }

        public SocialPulseDataContext(DbContextOptions<SocialPulseDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
