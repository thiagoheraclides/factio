using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using System.Data;
using Dapper;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {

        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public UserTypeRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public IDbConnection Connection { get => _connection; }
        public IDbTransaction Transaction { get => _transaction; set { _transaction = value; _context.Transaction = value; } }

        public Task<int> AddAsync(UserType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(UserType entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserType> GetByIdAsync(Guid id)
        {
            var sql = $"select user_type.* " +
                      $"from tb_user user " +
                      $"join tb_user_type user_type on user.typeid = user_type.id " +
                      $"where user.id = '{ id }'";
            return await _connection.QuerySingleAsync<UserType>(sql);
        }

        public Task<int> UpdateAsync(UserType entity)
        {
            throw new NotImplementedException();
        }
    }
}
