using Br.Com.FactIO.Application.Sites.Command;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.CommandHandler
{
    public class DeleteSiteCommandHandler : IRequestHandler<DeleteSiteCommand, OperationResult<Site>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSiteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Site>> Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
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

                site.DeleteSite(request.DeletedBy);

                var affectedRows = await _unitOfWork.SiteRepository.DeleteAsync(site);

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
