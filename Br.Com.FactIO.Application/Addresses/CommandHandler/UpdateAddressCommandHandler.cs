using Br.Com.FactIO.Application.Addresses.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.CommandHandler
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, OperationResult<Address>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Address>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Address>();

            try
            {
                var address = await _unitOfWork.AddressRepository.GetByIdAsync(Guid.Parse(request.Id));

                if (address == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Área não encontrada.");
                    return result;
                }

                address.UpdateAddress(request.PublicName, request.ZipCode, request.City, request.State, request.Country, request.LastUpdatedBy);

                var affectedRows = await _unitOfWork.AddressRepository.UpdateAsync(address);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
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
