using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.Commands
{
    public class DeleteStatus : IRequest<OperationResult<Status>>
    {
        public Guid StatusId { get; set; }
        public string DeletedBy { get; set; }
    }
}
