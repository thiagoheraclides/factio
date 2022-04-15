using Br.Com.FactIO.Domain.Entities;

namespace Br.Com.FactIO.Domain.Repositories
{
    public interface ICredentialRepository : IGenericRepository<Credential>
    {
        Task<bool> CheckCredentialAsync(Credential credential);
        Task<Credential> GetByUserName(string userName);
    }
}
