using Application.Common.Models;
using Application.ViewModels;
using Domain.Common;
using MediatR;

namespace Application.Domain.Queries;

public class GetEmailsQuery: Command<ApiResult<IList<EmailViewModel>>>
{
    public GetEmailsQuery(int page, int pageSize)
    {
        PageSize = pageSize;
        Page = page;
    }

    public int PageSize { get; set; }
    public int Page { get; set; }
}