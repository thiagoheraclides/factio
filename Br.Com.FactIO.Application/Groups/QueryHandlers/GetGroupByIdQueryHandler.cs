using Br.Com.FactIO.Application.Groups.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.QueryHandlers
{
    public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupById, OperationResult<Group>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGroupByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Group>> Handle(GetGroupById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Group>();

            try
            {
                var group = await _unitOfWork.GroupRepository.GetByIdAsync(request.Id);
                if (group == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Centro de custo não encontrado.");
                    return result;
                }

                result.Payload = group;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
