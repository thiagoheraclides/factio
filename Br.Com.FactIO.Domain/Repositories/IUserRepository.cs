using Br.Com.FactIO.Domain.Entities;

namespace Br.Com.FactIO.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserNameAsync(string username);
        Task<Boolean> CheckPasswordAsync(string username, string password);
        
    }
}
