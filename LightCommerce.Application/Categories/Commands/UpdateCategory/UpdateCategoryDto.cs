using LightCommerce.Application.Common.Exceptions;
using LightCommerce.Application.Common.Interfaces.Repositories;
using LightCommerce.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LightCommerce.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryDto : IRequest<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryDto, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            category.Name = request.Name;
            await _categoryRepository.UpdateAsync(category);
            return category;
        }
    }
}
