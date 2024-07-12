using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoPlanck.Application.Behaviors;
using MotoPlanck.Application.Core.Authentications.Contracts.Responses;
using MotoPlanck.Application.Services.JwtBearer;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MotoPlanck.Application
{
    /// <summary>
    /// Contains the extensions method for registering dependencies in the DI framework.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IJwtBearerService<LoginAuthenticationResponse>>(sp =>
            {
                return new JwtBearerService(configuration);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddGlobalIgnore("property");
            });


            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
