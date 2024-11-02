namespace Application.Common.Models;

public class PaginationInfo
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public long Total { get; set; }

    public PaginationInfo(int page, int pageSize, long total)
    {
        Page = page;
        PageSize = pageSize;
        Total = total;
    }
}