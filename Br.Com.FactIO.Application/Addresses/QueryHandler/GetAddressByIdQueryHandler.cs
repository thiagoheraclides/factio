using Br.Com.FactIO.Application.Addresses.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.QueryHandler
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, OperationResult<Address>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAddressByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Address>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Address>();

            try
            {
                var address = await _unitOfWork.AddressRepository.GetByIdAsync(Guid.Parse(request.Id));
                if (address == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Endereço não encontrado.");
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
