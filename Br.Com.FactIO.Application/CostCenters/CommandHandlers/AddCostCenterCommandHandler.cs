using Br.Com.FactIO.Application.CostCenters.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.CostCenters.CommandHandlers
{
    public class AddCostCenterCommandHandler : IRequestHandler<AddCostCenter, OperationResult<CostCenter>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCostCenterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<CostCenter>> Handle(AddCostCenter request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<CostCenter>();

            try
            {
                var costCenter = CostCenter.CreateCostCenter(request.CompanyId, request.Code, request.Name, request.Description, request.CreatedBy);
                var affectedRows = await _unitOfWork.CostCenterRepository.AddAsync(costCenter);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Erro ao inserir categoria.");
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
