using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Application.Zones.Query;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.QueryHandler
{
    public class GetAllZonesQueryHandler : IRequestHandler<GetAllZonesQuery, OperationResult<List<Zone>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllZonesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Zone>>> Handle(GetAllZonesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Zone>>();

            try
            {
                var zones = await _unitOfWork.ZoneRepository.GetAllAsync();
                result.Payload = zones.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
