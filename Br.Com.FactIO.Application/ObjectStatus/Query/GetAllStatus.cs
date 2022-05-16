using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;


namespace Br.Com.FactIO.Application.ObjectStatus.Query
{
    public class GetAllStatus : IRequest<OperationResult<List<Status>>>
    {

    }
}
