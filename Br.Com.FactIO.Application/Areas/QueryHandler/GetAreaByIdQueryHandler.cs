using Br.Com.FactIO.Application.Areas.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Areas.QueryHandler
{
    public class GetAreaByIdQueryHandler : IRequestHandler<GetAreaByIdQuery, OperationResult<Area>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAreaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Area>> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Area>();

            try
            {
                var area = await _unitOfWork.AreaRepository.GetByIdAsync(request.Id);
                if (area == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Área não encontrada.");
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
