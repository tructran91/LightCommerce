using LightCommerce.Application.Common.Interfaces.Repositories;
using LightCommerce.Domain.Entities;
using LightCommerce.Infrastructure.Data;

namespace LightCommerce.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
