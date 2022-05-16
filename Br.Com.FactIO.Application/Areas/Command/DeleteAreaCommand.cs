using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Areas.Command
{
    public class DeleteAreaCommand : IRequest<OperationResult<Area>>
    {
        public string Id { get; set; }
        public string DeletedBy { get; set; }

    }
}
