using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public ZoneRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public async Task<int> AddAsync(Zone entity)
        {
            var sql = @"insert into tb_zone (id, companyid, areaid, code, description, notes, active, createdby, createdon) 
                        values (@id, @company, @areaid, @code, @description, @notes, @active, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Zone entity)
        {
            var sql = @"update tb_zone 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Zone>> GetAllAsync()
        {
            var sql = @"select * from tb_zone";
            return await _connection.QueryAsync<Zone>(sql);
        }

        public async Task<Zone> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_zone where id = '{ id }'";
            return await _connection.QuerySingleAsync<Zone>(sql);
        }

        public async Task<int> UpdateAsync(Zone entity)
        {
            var sql = @"update tb_zone 
                        set code = @code, description = @descrption, notes = @notes, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
