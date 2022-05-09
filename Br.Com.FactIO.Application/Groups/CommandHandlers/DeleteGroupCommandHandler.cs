using Br.Com.FactIO.Application.Groups.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.CommandHandlers
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroup, OperationResult<Group>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Group>> Handle(DeleteGroup request, CancellationToken cancellationToken)
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

                group.DeleteGroup(request.DeletedBy);

                var affectedRows = await _unitOfWork.GroupRepository.DeleteAsync(group);

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
