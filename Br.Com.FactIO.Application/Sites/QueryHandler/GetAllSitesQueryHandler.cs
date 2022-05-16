using Br.Com.FactIO.Application.Sites.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Sites.QueryHandler
{
    public class GetAllSitesQueryHandler : IRequestHandler<GetAllSitesQuery, OperationResult<List<Site>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSitesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Site>>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Site>>();

            try
            {
                var sites = await _unitOfWork.SiteRepository.GetAllAsync();
                result.Payload = sites.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
