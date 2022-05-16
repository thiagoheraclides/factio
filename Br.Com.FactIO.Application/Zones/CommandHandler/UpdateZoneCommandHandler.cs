using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Application.Zones.Command;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.CommandHandler
{
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, OperationResult<Zone>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateZoneCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Zone>> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
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

                zone.UpdateZone(request.Code, request.Description, request.Notes, request.LastUpdatedBy);               

                var affectedRows = await _unitOfWork.ZoneRepository.UpdateAsync(zone);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
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
