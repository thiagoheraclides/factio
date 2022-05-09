using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using System.Data;
using Dapper;


namespace Br.Com.FactIO.Infra.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public UserRoleRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public IDbConnection Connection { get => _connection; }
        public IDbTransaction Transaction { get => _transaction; set { _transaction = value; _context.Transaction = value; } }


        public Task<int> AddAsync(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRole>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserRole> GetByIdAsync(Guid id)
        {
            var sql = $"select user_role.* " +
                      $"from tb_user user " +
                      $"join tb_user_role user_role on user.roleid = user_role.id " +
                      $"where user.id = '{ id }'";
            return await _connection.QuerySingleAsync<UserRole>(sql);
        }

        public Task<int> UpdateAsync(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
