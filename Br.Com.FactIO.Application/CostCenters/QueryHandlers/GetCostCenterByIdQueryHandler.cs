using Br.Com.FactIO.Application.CostCenters.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.CostCenters.QueryHandlers
{
    public class GetCostCenterByIdQueryHandler : IRequestHandler<GetCostCenterById, OperationResult<CostCenter>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCostCenterByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<CostCenter>> Handle(GetCostCenterById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<CostCenter>();

            try
            {
                var costCenter = await _unitOfWork.CostCenterRepository.GetByIdAsync(request.Id);
                if (costCenter == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Centro de custo não encontrado.");
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
