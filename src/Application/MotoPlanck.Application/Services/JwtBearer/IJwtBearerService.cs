namespace MotoPlanck.Application.Services.JwtBearer
{
    public interface IJwtBearerService<T> where T : class
    {
        Task<string> GenerateTokenAsync(T user, CancellationToken cancellationToken);
        Task<List<string>> ValidateTokenAsync(string token, CancellationToken cancellationToken);
    }
}
