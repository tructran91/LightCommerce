using LightCommerce.Application.Common.Interfaces.Repositories;
using LightCommerce.Application.Common.Models;
using LightCommerce.Application.Products.Queries.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LightCommerce.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<PagedResponse<IEnumerable<ProductDto>>>
    {
        public PaginationFilter PaginationFilter { get; set; }

        public GetProductsQuery(PaginationFilter paginationFilter)
        {
            PaginationFilter = paginationFilter;
        }
    }

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, PagedResponse<IEnumerable<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResponse<IEnumerable<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000); // sleep to test log
            var validFilter = new PaginationFilter(request.PaginationFilter.PageNumber, request.PaginationFilter.PageSize);

            var products = await _productRepository.GetAllAsync();
            var productsDto = products.Select(t => new ProductDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price
            });
            var pagedData = productsDto.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                .Take(validFilter.PageSize)
                                .ToList();
            var totalRecords = products.Count();
            var pagedReponse = new PagedResponse<IEnumerable<ProductDto>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalRecords);

            return await Task.FromResult(pagedReponse);
        }
    }
}
