using Br.Com.FactIO.Application.Companys.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.QueryHandlers
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyById, OperationResult<Company>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompanyByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Company>> Handle(GetCompanyById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Company>();
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.CompanyId);

            if (company is null)
            {
                result.AddError(704, "Compania não encontrada.");
                return result;
            }

            result.Payload = company;
            return result;
        }
    }
}
