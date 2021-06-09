namespace FaceControlApp.FaceApi
{
    using AutoMapper.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddFaceApi(this IServiceCollection services)
        {
            //services.AddScoped<IFaceControlAppDbContext>(provider => provider.GetService<FaceControlAppDbContext>());

            return services;
        }
    }
}
