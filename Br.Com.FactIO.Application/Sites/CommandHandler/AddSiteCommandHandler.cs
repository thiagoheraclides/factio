using Br.Com.FactIO.Application.Sites.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.CommandHandler
{
    public class AddSiteCommandHandler : IRequestHandler<AddSiteCommand, OperationResult<Site>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSiteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Site>> Handle(AddSiteCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Site>();

            try
            {
                var company = await _unitOfWork.CompanyRepository.GetByIdAsync(Guid.Parse(request.CompanyId));

                if (company is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Companhia não encontrada.");
                    return result;
                }

                var site = Site.CreateSite(request.Code, request.Name, request.Notes, request.CompanyId, request.CreatedBy);
                var affectedRows = await _unitOfWork.SiteRepository.AddAsync(site);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Erro processar requisição. Entre em contato com o suporte.");
                    return result;
                }

                result.Payload = site;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
