using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.Query
{
    public class GetAllGroups : IRequest<OperationResult<List<Group>>>
    {

    }
}
