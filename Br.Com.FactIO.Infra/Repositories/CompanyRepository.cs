using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using System.Data;
using Dapper;

namespace Br.Com.FactIO.Infra.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _connection = context.Connection;
            _transaction = context.Transaction;
            _context = context;
        }

        public IDbConnection Connection { get => _connection; }
        public IDbTransaction Transaction { get => _transaction; set { _transaction = value; _context.Transaction = value; } }

        public async Task<int> AddAsync(Company entity)
        {
            var sql = @"insert into tb_company (Id, Alias, FullName, Active, CreatedBy, CreatedOn) 
                        values (@Id, @Alias, @FullName, @Active, @CreatedBy, @CreatedOn)";

            return await _connection.ExecuteAsync(sql,entity);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Company entity)
        {
            var sql = @"update tb_company 
                        set active = @active, deletedby = @deletedby, deletedon = @deletedon
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var sql = $"select * from tb_company";
            return await _connection.QueryAsync<Company>(sql);
        }

        public async Task<Company> GetByIdAsync(Guid id)
        {
            var sql = $"select * from tb_company where id = '{ id }'";
            return await _connection.QuerySingleAsync<Company>(sql);
        }

        public async Task<int> UpdateAsync(Company entity)
        {
            var sql = @"update tb_company 
                        set alias = @alias, fullname = @fullname, lastupdatedby = @lastupdatedby, lastupdatedon = @lastupdatedon
                        where id = @id";
            return await _connection.ExecuteAsync(sql, entity);
        }
    }
}
