namespace MotoPlanck.WebApi.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationExtension(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Administrator")); //TODO Melhorar desempenho do Login
                options.AddPolicy("DeliverymanPolicy", policy => policy.RequireRole("Deliveryman"));
            });

            services.AddAuthorization();

            return services;
        }
    }
}
