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
        public IStatusRepository StatusRepository { get; }
        public ISiteRepository SiteRepository { get; }
        public IAreaRepository AreaRepository { get; }
        public IAddressRepository AddressRepository { get; }
        public IZoneRepository ZoneRepository { get; }

        public UnitOfWork(
            IUserRepository userRepository,
            IUserTypeRepository userTypeRepository,
            IUserRoleRepository userRoleRepository,
            ICompanyRepository companyRepository,
            ICategoryRepository categoryRepository,
            ICostCenterRepository costCenterRepository,
            IGroupRepository groupRepository,
            IStatusRepository statusRepository,
            ISiteRepository siteRepository,
            IAreaRepository areaRepository,
            IAddressRepository addressRepository,
            IZoneRepository zoneRepository)
        {
            UserRepository = userRepository;
            UserTypeRepository = userTypeRepository;
            UserRoleRepository = userRoleRepository;
            CompanyRepository = companyRepository;
            CategoryRepository = categoryRepository;
            CostCenterRepository = costCenterRepository;
            GroupRepository = groupRepository;
            StatusRepository = statusRepository;
            SiteRepository = siteRepository;
            AreaRepository = areaRepository;
            AddressRepository = addressRepository;
            ZoneRepository = zoneRepository;
        }
    }
}
