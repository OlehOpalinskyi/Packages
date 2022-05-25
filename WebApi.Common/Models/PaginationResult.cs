using System.Collections.Generic;

namespace WebApi.Common.Models
{
    public class PaginationResult<T> where T : class
    {
        public PaginationResult(int pageNumber, int pageSize, int totalItems, IEnumerable<T> data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            Data = data;
        }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public IEnumerable<T> Data { get; }

        public static PaginationResult<T> Empty()
        {
            return new PaginationResult<T>(1, 10, 0, new List<T>());
        }
    }
}