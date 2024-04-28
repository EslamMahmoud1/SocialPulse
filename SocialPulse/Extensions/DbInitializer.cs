using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialPulse;
using SocialPulse.Core.Models;
using SocialPulse.Repository.Data.Context;
using SocialPulse.Repository.Data.Seeding;


namespace SocialPulse.Extensions
{
    public static class DbInitializer
    {
        public static async Task InitializeDbAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();
                var context = service.GetRequiredService<SocialPulseDataContext>();
                var userManager = service.GetRequiredService<UserManager<User>>();

                try
                {
                    if ((await context.Database.GetPendingMigrationsAsync()).Any()) 
                    {
                       await context.Database.MigrateAsync();
                    }
                    await DataSeeding.DataSeedAsync(userManager);
                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<Program>();

                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
