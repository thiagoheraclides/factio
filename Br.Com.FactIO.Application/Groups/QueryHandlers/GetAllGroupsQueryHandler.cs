using Br.Com.FactIO.Application.Groups.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.QueryHandlers
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroups, OperationResult<List<Group>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGroupsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Group>>> Handle(GetAllGroups request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Group>>();

            try
            {
                var groups = await _unitOfWork.GroupRepository.GetAllAsync();
                result.Payload = groups.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
