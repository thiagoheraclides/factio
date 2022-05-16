using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.Command
{
    public class AddZoneCommand : IRequest<OperationResult<Zone>>
    {
        public string CompanyId { get; set; }
        public string AreaId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
    }
}
