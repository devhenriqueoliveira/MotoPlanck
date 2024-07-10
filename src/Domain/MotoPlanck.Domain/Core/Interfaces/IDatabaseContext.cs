using System.Data;

namespace MotoPlanck.Domain.Core.Interfaces
{
    public interface IDatabaseContext : IDisposable
    {
        IDbTransaction Transaction { get; }
        IDbConnection Connection { get; }
    }
}
