namespace RecruitmentSITHEC.Helpers.Pagination;

public class Paginator<T> where T : class
{
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public int Total { get; private set; }
    public IEnumerable<T> Data { get; private set; }

    public Paginator(IEnumerable<T> CollectionList, int total, int pageIndex, int pageSize)
    { 
        Data = CollectionList;
        Total = total;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public int TotalPages
    {
        get
        {
            return (int)Math.Ceiling(Total / (double)PageSize);
        }
    }

    public bool HasPreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (PageIndex < TotalPages);
        }
    }
}
