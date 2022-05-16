using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.Command
{
    public class DeleteZoneCommand : IRequest<OperationResult<Zone>>
    {
        public string Id { get; set; }
        public string DeletedBy { get; set; }
    }
}
