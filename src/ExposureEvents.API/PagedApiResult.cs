using System.Collections.Generic;

namespace ExposureEvents.API
{
    public class PagedApiResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}