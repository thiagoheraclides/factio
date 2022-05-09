using Br.Com.FactIO.Application.Companys.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.QueryHandlers
{
    public class GetAllCompanysHandler : IRequestHandler<GetAllCompanys, OperationResult<List<Company>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCompanysHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Company>>> Handle(GetAllCompanys request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Company>>();

            try
            {
                var companys = await _unitOfWork.CompanyRepository.GetAllAsync();
                result.Payload = companys.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
