using Br.Com.FactIO.Application.ObjectStatus.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.QueryHandler
{
    public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusById, OperationResult<Status>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStatusByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Status>> Handle(GetStatusById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Status>();

            try
            {
                var status = await _unitOfWork.StatusRepository.GetByIdAsync(request.Id);
                if (status == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Status não encontrado.");
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
