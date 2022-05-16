namespace Br.Com.FactIO.Domain.Repositories
{
    public interface IUnitOfWork
    { 
        IUserRepository UserRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICostCenterRepository CostCenterRepository { get; }
        IGroupRepository GroupRepository { get; }
        IStatusRepository StatusRepository { get; }
        ISiteRepository SiteRepository { get; }
        IAreaRepository AreaRepository { get; }
        IAddressRepository AddressRepository { get; }
        IZoneRepository ZoneRepository { get; }

    }
}
