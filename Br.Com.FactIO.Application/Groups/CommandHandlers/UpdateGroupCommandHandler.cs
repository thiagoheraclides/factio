using Br.Com.FactIO.Application.Groups.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.CommandHandlers
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroup, OperationResult<Group>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Group>> Handle(UpdateGroup request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Group>();

            try
            {
                var group = await _unitOfWork.GroupRepository.GetByIdAsync(request.GroupId);

                if (group is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Grupo não encontrado.");
                    return result;
                }

                group.UpdateGroup(request.Code, request.Name, request.Description, request.LastUpdatedBy);

                var affectedRows = await _unitOfWork.GroupRepository.UpdateAsync(group);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
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
