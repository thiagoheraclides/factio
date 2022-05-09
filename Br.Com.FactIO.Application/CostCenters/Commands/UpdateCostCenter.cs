using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.CostCenters.Commands
{
    public class UpdateCostCenter : IRequest<OperationResult<CostCenter>>
    {
        public Guid CostCenterId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
