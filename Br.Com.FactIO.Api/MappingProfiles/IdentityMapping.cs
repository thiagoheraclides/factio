using AutoMapper;
using Br.Com.FactIO.Api.Contracts.Company;
using Br.Com.FactIO.Api.Contracts.Identity;
using Br.Com.FactIO.Application.Companys.Commands;
using Br.Com.FactIO.Application.Identity.Commands;

namespace Br.Com.FactIO.Api.MappingProfiles
{
    public class IdentityMapping : Profile
    {
        public IdentityMapping()
        {
            CreateMap<Credential, LoginCommand>();
            CreateMap<AddCompanyRequest, AddCompany>();           
        }
    }
}
