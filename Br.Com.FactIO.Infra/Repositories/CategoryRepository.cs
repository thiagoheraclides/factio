using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public async Task<int> AddAsync(Category entity)
        {
            var sql = @"insert into tb_category (id, companyid, code, name, description, active, createdby, createdon)
                        values (@id, @companyid, @code, @name, @description, @active, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Category entity)
        {
            var sql = @"update tb_category 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var sql = $"select * from tb_category";
            return await _connection.QueryAsync<Category>(sql);
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_category where id = '{ id }'";
            return await _connection.QuerySingleAsync<Category>(sql);
        }

        public async Task<int> UpdateAsync(Category entity)
        {
            var sql = @"update tb_category 
                        set code = @code, name = @name, description = @description, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
