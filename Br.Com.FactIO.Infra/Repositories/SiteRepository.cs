using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public SiteRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public async Task<int> AddAsync(Site entity)
        {
            var sql = @"insert into tb_site 
                        (id, companyid, code, name, notes, active, createdby, createdon) 
                        values 
                        (@id, @companyid, @code, @name, @notes, @active, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Site entity)
        {
            var sql = @"update tb_site 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Site>> GetAllAsync()
        {
            var sql = @"select * from tb_site";
            return await _connection.QueryAsync<Site>(sql);
        }

        public async Task<Site> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_site where id = '{ id }'";
            return await _connection.QuerySingleAsync<Site>(sql);
        }

        public async Task<int> UpdateAsync(Site entity)
        {
            var sql = @"update tb_site 
                        set code = @code, name = @name, notes = @notes, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
