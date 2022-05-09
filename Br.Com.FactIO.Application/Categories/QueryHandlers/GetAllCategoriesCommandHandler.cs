using Br.Com.FactIO.Application.Categories.Query;
using Br.Com.FactIO.Application.Models;
using Br.Com.FactIO.Domain.Entities;
using Br.Com.FactIO.Domain.Repositories;
using MediatR;

namespace Br.Com.FactIO.Application.Categories.QueryHandlers
{
    public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllCategories, OperationResult<List<Category>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<List<Category>>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Category>>();

            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
                result.Payload = categories.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
