using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.Commands
{
    public class AddStatus : IRequest<OperationResult<Status>>
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
    }
}
