using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ryada.Models

{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((Math.Abs(pageIndex - 1)) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, Math.Abs(pageIndex), pageSize);
        }
        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip(((Math.Abs(pageIndex - 1))) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, Math.Abs(pageIndex), pageSize);
        }
    }



    public class PagintingFooterModel
    {
        public PagintingFooterModel(int pageID, string next, string previous, int totalPages = 0)
        {
            PageID = pageID;
            Next = next;
            Previous = previous;
            TotalPages = totalPages;
        }

        public int PageID { get; set; }
        public int TotalPages { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}
