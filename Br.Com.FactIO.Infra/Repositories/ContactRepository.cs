using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public ContactRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public IDbConnection Connection { get => _connection; }
        public IDbTransaction Transaction { get => _transaction; set { _transaction = value; _context.Transaction = value; } }

        public Task<int> AddAsync(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> GetByIdAsync(Guid id)
        {
            var sql = "select * from tb_contact where Id = @id";
            var result = await _connection.QueryAsync<Contact>(sql, id);
            return result.FirstOrDefault();
        }

        public Task<int> UpdateAsync(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
