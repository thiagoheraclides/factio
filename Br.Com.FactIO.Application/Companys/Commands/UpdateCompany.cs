using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.Commands
{
    public class UpdateCompany : IRequest<OperationResult<Company>>
    {
        public Guid CompanyId { get; set; }
        public string Alias { get; set; }
        public string FullName { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
