using Br.Com.FactIO.Application.ObjectStatus.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.ObjectStatus.CommandHandler
{
    public class AddStatusCommandHandler : IRequestHandler<AddStatus, OperationResult<Status>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Status>> Handle(AddStatus request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Status>();

            try
            {
                var status = Status.CreateStatus(request.CompanyId, request.Name, request.CreatedBy);
                var affectedRows = await _unitOfWork.StatusRepository.AddAsync(status);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Erro processar requisição. Entre em contato com o suporte.");
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
