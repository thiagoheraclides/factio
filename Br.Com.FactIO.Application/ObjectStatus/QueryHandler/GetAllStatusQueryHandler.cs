using Br.Com.FactIO.Application.ObjectStatus.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.QueryHandler
{
    public class GetAllStatusQueryHandler : IRequestHandler<GetAllStatus, OperationResult<List<Status>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStatusQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Status>>> Handle(GetAllStatus request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Status>>();

            try
            {
                var status = await _unitOfWork.StatusRepository.GetAllAsync();
                result.Payload = status.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
