using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.Commands
{
    public class DeleteCompany : IRequest<OperationResult<Company>>
    {
        public Guid CompanyId { get; set; }
        public string DeletedBy { get; set; }
    }
}
