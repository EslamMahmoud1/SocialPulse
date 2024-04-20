using Microsoft.EntityFrameworkCore;
using SocialPulse;
using SocialPulse.Repository.Data.Context;


namespace Qizzely.API.Extensions
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

                try
                {
                    if ((await context.Database.GetPendingMigrationsAsync()).Any()) 
                    {
                       await context.Database.MigrateAsync();
                    }
                    
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
