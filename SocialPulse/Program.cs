using Microsoft.EntityFrameworkCore;
using SocialPulse.API.Extensions;
using SocialPulse.Core.Interfaces.Repositories;
using SocialPulse.Core.Interfaces.Services;
using SocialPulse.Extensions;
using SocialPulse.Repository.Data.Context;
using SocialPulse.Repository.Repos;
using SocialPulse.Service;
using System.Reflection;

namespace SocialPulse
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //builder.Services.AddDbContext<SocialPulseDataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ESqlConnection")));

            builder.Services.AddDbContext<SocialPulseDataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MoSqlConnection")));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerService();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IAccountService , AccountService>();
            builder.Services.AddScoped<ITokenService , TokenService>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddIdentityService(builder.Configuration);
            var app = builder.Build();

            await DbInitializer.InitializeDbAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
