namespace JuliePro.Services
{
    using Microsoft.EntityFrameworkCore;

    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; internal set; }
        public int PageSize { get; internal set; }
        public int TotalCount { get; internal set; }
        public int TotalPages { get; internal set; }

        public PaginatedList()
        {

        }

        public PaginatedList(int pageIndex, int pageSize, int totalCount, int totalPages, IEnumerable<T> items) : base(items)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;

        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 0;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex + 1 < TotalPages;
            }
        }
    }

    public static class PaginatedListExtensions
    {
        public async static Task<PaginatedList<T>> ToPaginatedAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize)
        {
            var result = new PaginatedList<T>();
            result.PageIndex = pageIndex;
            result.PageSize = pageSize;

            // Une requête rapide pour obtenir le nombre d'éléments total
            result.TotalCount = await source.CountAsync();
            result.TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize);

            // Une requête pour obtenir les éléments qui sont sur la page présentée
            result.AddRange(await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());
            return result;
        }

    }
}
