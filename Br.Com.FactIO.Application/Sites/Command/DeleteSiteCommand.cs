using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.Command
{
    public class DeleteSiteCommand : IRequest<OperationResult<Site>>
    {
        public Guid SiteId { get; set; }
        public string DeletedBy { get; set; }
    }
}
