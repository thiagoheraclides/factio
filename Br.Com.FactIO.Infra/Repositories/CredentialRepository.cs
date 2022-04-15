using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public CredentialRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public IDbConnection Connection { get => _connection; }
        public IDbTransaction Transaction { get => _transaction; set { _transaction = value; _context.Transaction = value; } }

        public Task<int> AddAsync(Credential entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckCredentialAsync(Credential credential)
        {
            var sql = @"select if(count(*) > 0, true, false) 'CredentialExists' from tb_credentials
                        where Username = @Login and Password = @Password and Status = true";

            var result = await _connection.QueryAsync(sql, credential);

            return result.FirstOrDefault();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Credential>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Credential> GetByIdAsync(Guid id)
        {
            var sql = @"select * from tb_credentials where Id = @id";
            var result = await _connection.QueryAsync<Credential>(sql, id);
            return result.FirstOrDefault();
        }

        public async Task<Credential> GetByUserName(string userName)
        {
            var sql = $"select * from tb_credentials where username = '{userName}'";
            var result = await _connection.QueryAsync<Credential>(sql);
            return result.FirstOrDefault();
        }

        public Task<int> UpdateAsync(Credential entity)
        {
            throw new NotImplementedException();
        }
 
    }
}
