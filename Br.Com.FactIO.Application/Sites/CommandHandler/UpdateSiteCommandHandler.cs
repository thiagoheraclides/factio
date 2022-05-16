using Br.Com.FactIO.Application.Sites.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.CommandHandler
{
    public class UpdateSiteCommandHandler : IRequestHandler<UpdateSiteCommand, OperationResult<Site>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSiteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Site>> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Site>();

            try
            {
                var site = await _unitOfWork.SiteRepository.GetByIdAsync(request.SiteId);

                if (site is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Site não encontrado.");
                    return result;
                }

                site.UpdateSite(request.Code, request.Name, request.Notes, request.LastUpdatedBy);

                var affectedRows = await _unitOfWork.SiteRepository.UpdateAsync(site);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
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
