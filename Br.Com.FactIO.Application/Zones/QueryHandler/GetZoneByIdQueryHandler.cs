using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Application.Zones.Query;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.QueryHandler
{
    public class GetZoneByIdQueryHandler : IRequestHandler<GetZoneByIdQuery, OperationResult<Zone>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZoneByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Zone>> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Zone>();

            try
            {
                var zone = await _unitOfWork.ZoneRepository.GetByIdAsync(Guid.Parse(request.Id));

                if (zone is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Zona não encontrado.");
                    return result;
                }

                result.Payload = zone;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
