using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.Command
{
    public class AddAddressCommand : IRequest<OperationResult<Address>>
    {
        public string Owner { get; set; }
        public string PublicName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CreatedBy { get; set; }
    }
}
