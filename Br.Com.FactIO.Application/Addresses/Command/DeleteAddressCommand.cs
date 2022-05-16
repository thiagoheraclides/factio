using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.Command
{
    public class DeleteAddressCommand : IRequest<OperationResult<Address>>
    {
        public string Id { get; set; }
        public string DeletedBy { get; set; }
    }
}
