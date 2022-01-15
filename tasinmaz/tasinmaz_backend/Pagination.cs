using System.Collections.Generic;

namespace tasinmaz_backend
{
    public class PageResult<T>
    {
        public int count { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<T> Items { get; set; }        
    }
}