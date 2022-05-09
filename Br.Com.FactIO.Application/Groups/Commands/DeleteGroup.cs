using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.Commands
{
    public class DeleteGroup : IRequest<OperationResult<Group>>
    {
        public Guid GroupId { get; set; }
        public string DeletedBy { get; set; }
    }
}
