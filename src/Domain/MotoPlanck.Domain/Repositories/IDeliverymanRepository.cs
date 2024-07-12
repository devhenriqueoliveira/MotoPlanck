using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Interfaces;

namespace MotoPlanck.Domain.Repositories
{
    public interface IDeliverymanRepository : IGenericRepository<Deliveryman>
    {
        Task<bool> ExistsDeliverymanAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsCnpjAsync(string cnpj, CancellationToken cancellationToken);
        Task<bool> ExistsCnhAsync(string cnh, CancellationToken cancellationToken);
    }
}
