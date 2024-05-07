using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialPulse.Core.Models;

namespace SocialPulse.Repository.Data.Configurations
{
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            // Composite key
            //builder
            //.HasKey(f => new { f.RequesterId, f.AddresseeId}); 

            
            // Configure the relationship between Friend.Requester and User
            builder
                .HasOne(f => f.Requester)
                .WithMany()
                .HasForeignKey(f => f.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship between Friend.Addressee and User
            builder
                .HasOne(f => f.Addressee)
                .WithMany()
                .HasForeignKey(f => f.AddresseeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
