using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.Query
{
    public class GetCompanyById : IRequest<OperationResult<Company>>
    {
        public Guid CompanyId { get; set; }
    }
}
