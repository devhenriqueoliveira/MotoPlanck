using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Interfaces;
using MotoPlanck.Domain.Repositories;
using MotoPlanck.Infrastructure.Data.Contexts;
using MotoPlanck.Infrastructure.Data.Repositories;
using MotoPlanck.Infrastructure.Data.Uow;

namespace MotoPlanck.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDatabaseContext>(sp =>
            {
                var connectionString = configuration.GetConnectionString("MotoPlanckDatabaseConnection");
                return new DatabaseContext(connectionString!);
            });

            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
