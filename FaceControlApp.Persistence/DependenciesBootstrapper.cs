using FaceControlApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FaceControlApp.Persistence
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FaceControlAppDbContext>(options =>
            {

                options.UseSqlServer(
                        configuration.GetConnectionString("FaceControlAppConnection"),
                        b => b.MigrationsAssembly(typeof(FaceControlAppDbContext).Assembly.FullName));

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });


            services.AddScoped<IFaceControlAppDbContext>(provider => provider.GetService<FaceControlAppDbContext>());

            return services;
        }
    }
}
