using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Application.Zones.Command;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Zones.CommandHandler
{
    public class AddZoneCommandHandler : IRequestHandler<AddZoneCommand, OperationResult<Zone>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddZoneCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Zone>> Handle(AddZoneCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Zone>();

            try
            {
                var company = await _unitOfWork.CompanyRepository.GetByIdAsync(Guid.Parse(request.CompanyId));
                
                if (company is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Empresa não encontrada.");
                    return result;
                }

                var area = await _unitOfWork.AreaRepository.GetByIdAsync(Guid.Parse(request.AreaId));

                if (area is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Área não encontrada.");
                    return result;
                }

                var zone = Zone.CreateZone(request.CompanyId, request.AreaId, request.Code, request.Description, request.Notes, request.CreatedBy);
                
                var affectedRows = await _unitOfWork.ZoneRepository.AddAsync(zone);

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
