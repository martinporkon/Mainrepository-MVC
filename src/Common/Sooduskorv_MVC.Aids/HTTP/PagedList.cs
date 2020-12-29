using System;
using System.Collections.Generic;

namespace Sooduskorv_MVC.Aids.HTTP
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PagedList(IEnumerable<T> items, string currentPage, string pageSize, string totalCount)
        {
            TotalCount = int.Parse(totalCount);
            CurrentPage = int.Parse(currentPage);
            PageSize = int.Parse(pageSize);
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            AddRange(items);
        }
    }
}