using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.CostCenters.Commands
{
    public class DeleteCostCenter : IRequest<OperationResult<CostCenter>>
    {
        public Guid CostCenterId { get; set; }
        public string DeletedBy { get; set; }
    }
}
