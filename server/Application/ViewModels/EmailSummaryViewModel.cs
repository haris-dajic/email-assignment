using Application.Common.Models;

namespace Application.ViewModels;

public class EmailSummaryViewModel
{
    public IList<EmailViewModel> Emails { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
}