using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.Command
{
    public class UpdateSiteCommand : IRequest<OperationResult<Site>>
    {
        public Guid SiteId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
