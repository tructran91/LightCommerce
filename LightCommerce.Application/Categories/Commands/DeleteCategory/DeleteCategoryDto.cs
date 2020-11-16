using LightCommerce.Application.Common.Exceptions;
using LightCommerce.Application.Common.Interfaces.Repositories;
using LightCommerce.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LightCommerce.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryDto : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteCategoryDto(int id)
        {
            Id = id;
        }
    }

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryDto, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
            await _categoryRepository.DeleteAsync(category);
            return category.Id;
        }
    }
}
