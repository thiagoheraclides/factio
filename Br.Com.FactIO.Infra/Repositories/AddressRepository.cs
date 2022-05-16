using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using System.Data;
using Dapper;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public AddressRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public async Task<int> AddAsync(Address entity)
        {
            var sql = @"insert into tb_address (id, owner, zipocode, publicname, city, state, country, createdby, createdon) 
                        values (@id, @owner, @zipcode, @publicname, @city, @state, @country, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Address entity)
        {
            var sql = @"update tb_address 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            var sql = @"select * from tb_address";
            return await _connection.QueryAsync<Address>(sql);
        }

        public async Task<Address> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_address where id = '{ id }'";
            return await _connection.QuerySingleAsync<Address>(sql);
        }

        public async Task<int> UpdateAsync(Address entity)
        {
            var sql = @"update tb_address 
                        set zipcode = @zipcode, publicname = @publicname, city = @city, state = @state, country = @country, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
