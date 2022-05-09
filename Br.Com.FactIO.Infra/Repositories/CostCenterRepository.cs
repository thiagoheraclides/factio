using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public CostCenterRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public async Task<int> AddAsync(CostCenter entity)
        {
            var sql = @"insert into tb_cost_center (id, companyid, code, name, description, active, createdby, createdon)
                        values (@id, @companyid, @code, @name, @description, @active, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(CostCenter entity)
        {
            var sql = @"update tb_cost_center 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<CostCenter>> GetAllAsync()
        {
            var sql = $"select * from tb_cost_center";
            return await _connection.QueryAsync<CostCenter>(sql);
        }

        public async Task<CostCenter> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_cost_center where id = '{ id }'";
            return await _connection.QuerySingleAsync<CostCenter>(sql);
        }

        public async Task<int> UpdateAsync(CostCenter entity)
        {
            var sql = @"update tb_cost_center 
                        set code = @code, name = @name, description = @description, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
