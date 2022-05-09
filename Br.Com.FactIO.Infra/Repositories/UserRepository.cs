using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;


namespace Br.Com.FactIO.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public IDbConnection Connection { get => _connection; }
        public IDbTransaction Transaction { get => _transaction; set { _transaction = value; _context.Transaction = value; } }

        public Task<int> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckPasswordAsync(string username, string password)
        {
            var sql = $"select " +
                      $"if(count(*) > 0, true, false) IsValidCredential " +
                      $"from tb_user user " +
                      $"where user.username = '{ username }' and user.password = '{ password }' and user.active = true";
            return await _connection.QuerySingleAsync<bool>(sql);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_users where id = '{id}'";
            return await _connection.QueryFirstAsync<User>(sql);

        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            var sql = $"select " +
                        $"user.id, " +
                        $"user.username, " +
                        $"user_detail.fname, " +
                        $"user_detail.lname, " +
                        $"user.active, " +
                        $"user.createdby, " +
                        $"user.createdon, " +
                        $"user.lastupdatedby, " +
                        $"user.lastupdatedon, " +
                        $"user.deletedon, " +
                        $"user.deletedby " +                     
                      $"from tb_user user " +
                      $"join tb_user_detail user_detail on user.id = user_detail.id " +
                      $"where user.username = '{ username }' and user.active = true";            
            return await _connection.QuerySingleAsync<User>(sql);
        }

        public Task<int> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
