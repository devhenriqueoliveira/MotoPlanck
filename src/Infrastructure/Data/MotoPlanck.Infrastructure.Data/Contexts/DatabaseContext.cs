using MotoPlanck.Domain.Core.Interfaces;
using Npgsql;
using System.Data;

namespace MotoPlanck.Infrastructure.Data.Contexts
{
    internal sealed class DatabaseContext : IDatabaseContext
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public DatabaseContext(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
