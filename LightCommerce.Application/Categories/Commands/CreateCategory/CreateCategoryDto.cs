using LightCommerce.Application.Common.Interfaces.Repositories;
using LightCommerce.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LightCommerce.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto : IRequest<Category>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategoryDto, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CreateCategoryDto request, CancellationToken cancellationToken)
        {
            var category = new Category() { Name = request.Name };

            await _categoryRepository.AddAsync(category);

            return category;
        }
    }
}
