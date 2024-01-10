namespace MyWebAPIApp.Models
{
    public class PaginatedList<T> : List<T>
    {
         public int PageIndex {  get; set; }
        public int TotalPage { get; set; }
        public PaginatedList(List<T> item, int count, int pageIndex, int pageSize) {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(item);
        }

        public static PaginatedList<T> Create(IQueryable<T> query,int pageIndex, int pageSize)
        {
            var count=query.Count();
            var items = query.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
