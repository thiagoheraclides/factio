using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public StatusRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public async Task<int> AddAsync(Status entity)
        {
            var sql = @"insert into tb_status (id, companyid, name, active, createdby, createdon)
                        values (@id, @companyid, @name, @active, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Status entity)
        {
            var sql = @"update tb_status 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            var sql = $"select * from tb_status";
            return await _connection.QueryAsync<Status>(sql);
        }

        public async Task<Status> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_status where id = '{ id }'";
            return await _connection.QuerySingleAsync<Status>(sql);
        }

        public async Task<int> UpdateAsync(Status entity)
        {
            var sql = @"update tb_status 
                        set name = @name, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
