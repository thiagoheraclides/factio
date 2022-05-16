using Br.Com.FactIO.Application.Sites.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.QueryHandler
{
    public class GetSiteByIdQueryHandler : IRequestHandler<GetSiteByIdQuery, OperationResult<Site>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSiteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Site>> Handle(GetSiteByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Site>();

            try
            {
                var site = await _unitOfWork.SiteRepository.GetByIdAsync(request.Id);
                if (site == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Site não encontrado.");
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
