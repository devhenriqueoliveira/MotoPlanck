using MotoPlanck.Domain.Interfaces;
using MotoPlanck.Domain.Repositories;

namespace MotoPlanck.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IMotorcycleRepository Motorcycles { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IDeliverymanRepository Deliverymans { get; }
        IPlanRepository Plans { get; }
        IRentRepository Rentals { get; }
        Task<bool> RollBackAsync();
        Task<bool> CommitAsync();
    }
}
