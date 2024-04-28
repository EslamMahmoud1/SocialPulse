using Microsoft.AspNetCore.Identity;
using SocialPulse.Core.Models;

namespace SocialPulse.Repository.Data.Seeding
{
    public static class DataSeeding
    {
        public static async Task DataSeedAsync(UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var eslamUser = new User
                {
                    UserName = "EslamMahmoud",
                    Email = "EslamMahmoud@email.com",
                };
                var mohammedUser = new User
                {
                    UserName = "mohammedHany",
                    Email = "mohammedHany@email.com",
                };
                await userManager.CreateAsync(eslamUser, "P@ssword1234");
                await userManager.CreateAsync(mohammedUser, "P@ssword1234");
            }
        }
    }
}
