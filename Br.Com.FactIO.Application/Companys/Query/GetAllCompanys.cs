using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.Query
{
    public class GetAllCompanys : IRequest<OperationResult<List<Company>>>
    {

    }
}
