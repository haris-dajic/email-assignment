using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Domain.Queries;
using Application.ViewModels;
using Domain.Common;

namespace Application.Domain.Handlers;

public class GetEmailsQueryHandler: CommandHandler<GetEmailsQuery, ApiResult<IList<EmailViewModel>>>
{
    private IEmailRepository _emailRepository;

    public GetEmailsQueryHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }
    
    public override async Task<ApiResult<IList<EmailViewModel>>> Handle(GetEmailsQuery request, CancellationToken cancellationToken)
    {
        var emailsSummary = await _emailRepository.GetEmailsAsync(request.Page, request.PageSize, cancellationToken);
        return ApiResult<IList<EmailViewModel>>.Success().WithData(emailsSummary.Emails).WithMeta(emailsSummary.PaginationInfo);
    }
}