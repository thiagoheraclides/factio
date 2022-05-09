using Br.Com.FactIO.Application.Companys.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.CommandHandlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompany, OperationResult<Company>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Company>> Handle(UpdateCompany request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Company>();

            try
            {
                var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.CompanyId);

                if (company is null)
                {
                    result.AddError(704, "Companhia não encontrada.");
                    return result;
                }

                company.UpdateCompany(request.Alias, request.FullName, request.LastUpdatedBy);
                var rowsAffected = await _unitOfWork.CompanyRepository.UpdateAsync(company);

                if (rowsAffected > -1)
                    result.Payload = company;

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
