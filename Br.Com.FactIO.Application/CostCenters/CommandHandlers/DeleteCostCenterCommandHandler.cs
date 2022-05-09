using Br.Com.FactIO.Application.CostCenters.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.CostCenters.CommandHandlers
{
    public class DeleteCostCenterCommandHandler : IRequestHandler<DeleteCostCenter, OperationResult<CostCenter>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCostCenterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<CostCenter>> Handle(DeleteCostCenter request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<CostCenter>();

            try
            {
                var costCenter = await _unitOfWork.CostCenterRepository.GetByIdAsync(request.CostCenterId);

                if (costCenter is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Centro de custo não encontrado.");
                    return result;
                }

                costCenter.DeleteCostCenter(request.DeletedBy);

                var affectedRows = await _unitOfWork.CostCenterRepository.DeleteAsync(costCenter);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
                    return result;
                }

                result.Payload = costCenter;

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
