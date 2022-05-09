using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.CostCenters.Query
{
    public class GetAllCostCenters : IRequest<OperationResult<List<CostCenter>>>
    {

    }
}
