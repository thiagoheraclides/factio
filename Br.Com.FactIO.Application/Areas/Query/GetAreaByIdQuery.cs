using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Areas.Query
{
    public class GetAreaByIdQuery : IRequest<OperationResult<Area>>
    {
        public Guid Id { get; set; }
    }
}
