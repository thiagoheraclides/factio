using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Areas.Query
{
    public class GetAllAreasQuery : IRequest<OperationResult<List<Area>>>
    {

    }
}
