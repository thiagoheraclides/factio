using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.Commands
{
    public class UpdateGroup : IRequest<OperationResult<Group>>
    {
        public Guid GroupId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
