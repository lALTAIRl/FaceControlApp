namespace FaceControlApp.Application
{
    using System.Reflection;
    using FaceControlApp.Application.Behaviours;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}
