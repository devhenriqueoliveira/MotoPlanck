using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> ExistsUserAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsLoginAsync(string login, CancellationToken cancellationToken);
        Task<bool> ExistsEmailAsync(string email, CancellationToken cancellationToken);
        Task<Result<User>> GetUserByloginAsync(string login, CancellationToken cancellationToken);
    }
}
