using LightCommerce.Application.Categories.Queries.Dtos;
using LightCommerce.Application.Common.Interfaces;
using LightCommerce.Application.Common.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LightCommerce.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public GetCategoriesQuery()
        {
        }
    }

    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly IMemoryCacheManager _memoryCacheManager;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesHandler(IMemoryCacheManager memoryCacheManager,
            ICategoryRepository categoryRepository)
        {
            _memoryCacheManager = memoryCacheManager;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (!_memoryCacheManager.TryGetValue(nameof(GetCategoriesQuery), out IEnumerable<CategoryDto> categoryDtos))
            {
                var categories = await _categoryRepository.GetAllAsync();

                categoryDtos = categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                });

                _memoryCacheManager.Set(nameof(GetCategoriesQuery), categoryDtos);
            }

            return categoryDtos;
        }
    }
}
