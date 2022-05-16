using Br.Com.FactIO.Application.Addresses.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.CommandHandler
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, OperationResult<Address>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<OperationResult<Address>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
