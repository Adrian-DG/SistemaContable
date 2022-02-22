using System.Collections.Generic;

namespace API.DTO
{
    public class PagedDataDTO<T> : PaginationFilterDTO<T> where T : class
    {
        public IEnumerable<T> Records { get; set; }
    }
}