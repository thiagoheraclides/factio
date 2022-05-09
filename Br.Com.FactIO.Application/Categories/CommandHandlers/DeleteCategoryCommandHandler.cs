using Br.Com.FactIO.Application.Categories.Commands;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Categories.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategory, OperationResult<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Category>> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Category>();

            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);

                if (category is null)
                {
                    result.IsError = true;
                    result.AddError(99, "Categoria não encontrada.");
                    return result;
                }

                category.DeleteCategory(request.DeletedBy);

                var affectedRows = await _unitOfWork.CategoryRepository.DeleteAsync(category);

                if (affectedRows < 1)
                {
                    result.IsError = true;
                    result.AddError(99, "Não foi possível processar a solicitação. Entre em contato com o suporte.");
                    return result;
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
