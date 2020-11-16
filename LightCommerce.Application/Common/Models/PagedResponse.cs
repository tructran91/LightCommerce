using System;

namespace LightCommerce.Application.Common.Models
{
    public class PagedResponse<TOutput>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public TOutput Data { get; set; }

        public PagedResponse(TOutput data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Data = data;

            var totalPages = ((double)totalRecords / (double)pageSize);
            TotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            HasNextPage = (PageNumber <= TotalPages - 1);
            HasPreviousPage = (PageNumber > 1);
        }
    }
}
