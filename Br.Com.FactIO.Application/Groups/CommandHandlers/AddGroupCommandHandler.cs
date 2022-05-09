using Br.Com.FactIO.Application.Groups.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Groups.CommandHandlers
{
    public class AddGroupCommandHandler : IRequestHandler<AddGroup, OperationResult<Group>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Group>> Handle(AddGroup request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Group>();

            try
            {
                var group = Group.CreateGroup(request.CompanyId, request.Code, request.Name, request.Description, request.CreatedBy);
                var affectedRows = await _unitOfWork.GroupRepository.AddAsync(group);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Erro processar requisição. Entre em contato com o suporte.");
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
