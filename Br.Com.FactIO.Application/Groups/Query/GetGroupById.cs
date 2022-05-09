using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;


namespace Br.Com.FactIO.Application.Groups.Query
{
    public class GetGroupById : IRequest<OperationResult<Group>>
    {
        public Guid Id { get; set; }
    }
}
