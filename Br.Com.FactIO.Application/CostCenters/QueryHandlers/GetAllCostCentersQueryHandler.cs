using Br.Com.FactIO.Application.CostCenters.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.CostCenters.QueryHandlers
{
    public class GetAllCostCentersQueryHandler : IRequestHandler<GetAllCostCenters, OperationResult<List<CostCenter>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCostCentersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<CostCenter>>> Handle(GetAllCostCenters request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<CostCenter>>();

            try
            {
                var costCenters = await _unitOfWork.CostCenterRepository.GetAllAsync();
                result.Payload = costCenters.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
