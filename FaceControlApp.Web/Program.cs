namespace FaceControlApp.Web
{
    using FaceControlApp.Application.Interfaces;
    using FaceControlApp.Persistence;
    using FaceControlApp.Persistence.Seeds;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<IFaceControlAppDbContext>() as FaceControlAppDbContext;

                    if (context.Database.IsSqlServer())
                    {
                        context.Database.Migrate();
                    }

                    await FaceControlAppDbContextSeed.SeedSampleDataAsync(context);
                }
                catch
                {
                    
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
