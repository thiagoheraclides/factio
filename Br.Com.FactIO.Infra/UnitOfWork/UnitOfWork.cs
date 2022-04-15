using Br.Com.FactIO.Domain.Repositories;
using Br.Com.FactIO.Infra.Context;
using System.Data;

namespace Br.Com.FactIO.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    { 
        public IUserRepository UserRepository { get; }
        public IUserTypeRepository UserTypeRepository { get; }

        public IUserRoleRepository UserRoleRepository { get; }

        public UnitOfWork(
            IUserRepository userRepository,
            IUserTypeRepository userTypeRepository,
            IUserRoleRepository userRoleRepository)
        { 
            UserRepository = userRepository;
            UserTypeRepository = userTypeRepository;
            UserRoleRepository = userRoleRepository;
        }
    }
}
