using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.Query
{
    public class GetAllSitesQuery : IRequest<OperationResult<List<Site>>>
    {

    }
}
