using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.Query
{
    public class GetZoneByIdQuery : IRequest<OperationResult<Zone>>
    {
        public string Id { get; set; }
    }
}
