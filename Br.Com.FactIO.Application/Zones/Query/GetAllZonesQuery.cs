using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.Query
{
    public class GetAllZonesQuery : IRequest<OperationResult<List<Zone>>>
    {

    }
}
