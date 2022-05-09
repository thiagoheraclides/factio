using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using Dapper;
using System.Data;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public GroupRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }


        public async Task<int> AddAsync(Group entity)
        {
            var sql = @"insert into tb_group (id, companyid, code, name, description, active, createdby, createdon)
                        values (@id, @companyid, @code, @name, @description, @active, @createdby, @createdon)";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Group entity)
        {
            var sql = @"update tb_group 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            var sql = $"select * from tb_group";
            return await _connection.QueryAsync<Group>(sql);
        }

        public async Task<Group> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_group where id = '{ id }'";
            return await _connection.QuerySingleAsync<Group>(sql);
        }

        public async Task<int> UpdateAsync(Group entity)
        {
            var sql = @"update tb_group 
                        set code = @code, name = @name, description = @description, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon 
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }

}
