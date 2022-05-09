using Br.Com.FactIO.Application.Categories.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Categories.CommandHandlers
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategory, OperationResult<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Category>> Handle(AddCategory request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Category>();

            try
            {
                var category = Category.CreateCategory(request.CompanyId, request.Code, request.Name, request.Description, request.CreatedBy);
                var affectedRows = await _unitOfWork.CategoryRepository.AddAsync(category);

                if (affectedRows < 1)
                {                    
                    result.IsError = true;
                    result.AddError(99, "Erro ao inserir categoria.");
                }

                result.Payload = category;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
