using LightCommerce.Application.Common.Interfaces.Repositories;
using LightCommerce.Domain.Entities;
using LightCommerce.Infrastructure.Data;

namespace LightCommerce.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
