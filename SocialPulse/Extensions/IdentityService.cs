using Microsoft.AspNetCore.Identity;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Data.Context;

namespace SocialPulse.API.Extensions
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<User>().AddEntityFrameworkStores<SocialPulseDataContext>()
                .AddSignInManager<SignInManager<User>>();
            services.AddAuthentication();
            return services;
        }

    }
}
