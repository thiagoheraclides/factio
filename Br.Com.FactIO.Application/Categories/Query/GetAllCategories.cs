using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Categories.Query
{
    public class GetAllCategories : IRequest<OperationResult<List<Category>>>
    {

    }
}
