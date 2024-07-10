using MotoPlanck.Domain.Core.Interfaces;
using MotoPlanck.Domain.Interfaces;
using MotoPlanck.Domain.Repositories;

namespace MotoPlanck.Infrastructure.Data.Uow
{
    internal class UnitOfWork(
        IDatabaseContext context,
        IMotorcycleRepository motorcycleRepository,
        IUserRepository userRepository,
        IRoleRepository role,
        IDeliverymanRepository deliveryman,
        IPlanRepository plan,
        IRentRepository rent) : IUnitOfWork
    {
        public IMotorcycleRepository Motorcycles { get; } = motorcycleRepository;
        public IUserRepository Users { get; } = userRepository;
        public IRoleRepository Roles { get; } = role;
        public IDeliverymanRepository Deliverymans { get; } = deliveryman;
        public IPlanRepository Plans { get; } = plan;
        public IRentRepository Rentals { get; } = rent;


        private readonly IDatabaseContext _context = context;
        private bool _disposed;

        public async Task<bool> CommitAsync()
        {
            try
            {
                _context.Transaction.Commit();
                return await Task.FromResult(true);
            }
            catch
            {
                await RollBackAsync();
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> RollBackAsync()
        {
            try
            {
                _context.Transaction.Rollback();
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(true);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
