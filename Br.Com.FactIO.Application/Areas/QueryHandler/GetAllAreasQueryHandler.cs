using Br.Com.FactIO.Application.Areas.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Areas.QueryHandler
{
    public class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, OperationResult<List<Area>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAreasQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<OperationResult<List<Area>>> Handle(GetAllAreasQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Area>>();

            try
            {
                var areas = await _unitOfWork.AreaRepository.GetAllAsync();
                result.Payload = areas.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
