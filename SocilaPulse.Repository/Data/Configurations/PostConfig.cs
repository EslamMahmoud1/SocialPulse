using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialPulse.Core.Models;

namespace SocialPulse.Repository.Data.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.OwnsOne(p => p.Media, o => o.WithOwner());
        }
    }
}
