using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.Query
{
    public class GetSiteByIdQuery : IRequest<OperationResult<Site>>
    {
        public Guid Id { get; set; }
    }
}
