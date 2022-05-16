using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.Query
{
    public class GetAllAddressesQuery : IRequest<OperationResult<List<Address>>>
    {

    }
}
