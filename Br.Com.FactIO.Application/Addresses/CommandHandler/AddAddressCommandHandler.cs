using Br.Com.FactIO.Application.Addresses.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.CommandHandler
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, OperationResult<Address>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Address>> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Address>();

            try
            {
                var address = Address.CreateAddress(request.Owner, request.PublicName, request.ZipCode, request.City, request.State, request.Country, request.CreatedBy);
                var affectedRows = await _unitOfWork.AddressRepository.AddAsync(address);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Erro processar requisição. Entre em contato com o suporte.");
                    return result;
                }

                result.Payload = address;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
