using Br.Com.FactIO.Application.Areas.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Areas.CommandHandler
{
    public class AddAreaCommandHandler : IRequestHandler<AddAreaCommand, OperationResult<Area>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddAreaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Area>> Handle(AddAreaCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Area>();

            try
            {
                var company = await _unitOfWork.CompanyRepository.GetByIdAsync(Guid.Parse(request.CompanyId));

                if (company is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Empresa não encontrada.");
                    return result;
                }

                var site = await _unitOfWork.SiteRepository.GetByIdAsync(Guid.Parse(request.SiteId));

                if (company is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Site não encontrado.");
                    return result;
                }

                var area = Area.CreateArea(request.CompanyId, request.SiteId, request.Code, request.Description, request.Notes, request.CreatedBy);
                var affectedRows = await _unitOfWork.AreaRepository.AddAsync(area);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Erro processar requisição. Entre em contato com o suporte.");
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
