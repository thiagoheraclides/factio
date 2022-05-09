using Br.Com.FactIO.Application.Categories.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Categories.QueryHandlers
{
    public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryById, OperationResult<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Category>> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Category>();

            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
                if (category == null)
                {
                    result.IsError = true;
                    result.AddError(99, "Categoria não encontrada.");
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
