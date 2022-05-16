using Br.Com.FactIO.Application.ObjectStatus.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.CommandHandler
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatus, OperationResult<Status>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Status>> Handle(UpdateStatus request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Status>();

            try
            {
                var status = await _unitOfWork.StatusRepository.GetByIdAsync(request.StatusId);

                if (status is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Status não encontrado.");
                    return result;
                }

                status.UpdateStatus(request.Name, request.LastUpdatedBy);

                var affectedRows = await _unitOfWork.StatusRepository.UpdateAsync(status);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
                    return result;
                }

                result.Payload = status;

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
