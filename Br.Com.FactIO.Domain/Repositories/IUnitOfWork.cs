namespace Br.Com.FactIO.Domain.Repositories
{
    public interface IUnitOfWork
    { 
        IUserRepository UserRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }

    }
}
