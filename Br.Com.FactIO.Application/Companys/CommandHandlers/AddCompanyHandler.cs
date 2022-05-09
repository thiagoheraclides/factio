using AutoMapper;
using Br.Com.FactIO.Application.Companys.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Companys.CommandHandlers
{
    public class AddCompanyHandler : IRequestHandler<AddCompany, OperationResult<Company>>
    {
        private readonly IUnitOfWork _unitOfWork;       

        public AddCompanyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<OperationResult<Company>> Handle(AddCompany request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Company>();

            try
            {
                var company = Company.CreateCompany(request.Alias, request.FullName, request.CreatedBy);
                var rowsAffected = await _unitOfWork.CompanyRepository.AddAsync(company);
                result.Payload = company;
            }
            catch (Exception e)
            {
                result.AddError(99, e.Message);
            }

            return result;
        }
    }
}
