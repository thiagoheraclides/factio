using Br.Com.FactIO.Application.Addresses.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Addresses.QueryHandler
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, OperationResult<List<Address>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAddressesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Address>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Address>>();

            try
            {
                var addresses = await _unitOfWork.AddressRepository.GetAllAsync();
                result.Payload = addresses.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
