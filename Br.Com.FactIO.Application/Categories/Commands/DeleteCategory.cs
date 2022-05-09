using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Categories.Commands
{
    public class DeleteCategory : IRequest<OperationResult<Category>>
    {
        public Guid CategoryId { get; set; }
        public string DeletedBy { get; set; }
    }
}
