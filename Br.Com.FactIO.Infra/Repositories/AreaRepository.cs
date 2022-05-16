using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public AreaRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public async Task<int> AddAsync(Area entity)
        {
            var sql = @"insert into tb_area (id, companyid, siteid, code, description, notes, active, createdby, createdon) 
                        values (@id, @company, @siteid, @code, @description, @notes, @active, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Area entity)
        {
            var sql = @"update tb_area 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            var sql = @"select * from tb_area";
            return await _connection.QueryAsync<Area>(sql);
        }

        public async Task<Area> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_area where id = '{ id }'";
            return await _connection.QuerySingleAsync<Area>(sql);
        }

        public async Task<int> UpdateAsync(Area entity)
        {
            var sql = @"update tb_area 
                        set code = @code, description = @descrption, notes = @notes, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
