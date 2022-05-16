using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.Commands
{
    public class UpdateStatus : IRequest<OperationResult<Status>>
    {
        public Guid StatusId { get; set; }
        public string Name { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
