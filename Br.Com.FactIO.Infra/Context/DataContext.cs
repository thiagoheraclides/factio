using MySql.Data.MySqlClient;
using System.Data;

namespace Br.Com.FactIO.Infra.Context
{
    public interface IDbConnectionProvider
    {
        IDbConnection Connection { get; }
    }

    public class DataContext : IDbConnectionProvider
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public DataContext(string connection)
        {
            _connection = new MySqlConnection(connection);
        }

        public IDbConnection Connection { get => _connection; }
        public IDbTransaction Transaction { get => _transaction; set => _transaction = value; }

    }
}
