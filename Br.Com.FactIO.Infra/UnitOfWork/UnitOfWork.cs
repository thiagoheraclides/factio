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
        public ICompanyRepository CompanyRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICostCenterRepository CostCenterRepository { get; }
        public IGroupRepository GroupRepository { get; }

        public UnitOfWork(
            IUserRepository userRepository,
            IUserTypeRepository userTypeRepository,
            IUserRoleRepository userRoleRepository,
            ICompanyRepository companyRepository,
            ICategoryRepository categoryRepository,
            ICostCenterRepository costCenterRepository,
            IGroupRepository groupRepository)
        {
            UserRepository = userRepository;
            UserTypeRepository = userTypeRepository;
            UserRoleRepository = userRoleRepository;
            CompanyRepository = companyRepository;
            CategoryRepository = categoryRepository;
            CostCenterRepository = costCenterRepository;
            GroupRepository = groupRepository;
        }
    }
}
