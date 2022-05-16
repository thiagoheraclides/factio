using Br.Com.FactIO.Application.Areas.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Areas.CommandHandler
{
    public class UpdateAreaCommandHandler : IRequestHandler<UpdateAreaCommand, OperationResult<Area>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAreaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Area>> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Area>();

            try
            {
                var area = await _unitOfWork.AreaRepository.GetByIdAsync(Guid.Parse(request.Id));

                if (area == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Área não encontrada.");
                    return result;
                }

                area.UpdateArea(request.Code, request.Description, request.Notes, request.LastUpdatedBy);

                var affectedRows = await _unitOfWork.AreaRepository.UpdateAsync(area);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
                    return result;
                }

                result.Payload = area;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
