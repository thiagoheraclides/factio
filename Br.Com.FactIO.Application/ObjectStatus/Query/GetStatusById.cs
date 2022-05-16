using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.Query
{
    public class GetStatusById : IRequest<OperationResult<Status>>
    {
        public Guid Id { get; set; }
    }
}
