using Application.ViewModels;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IEmailRepository
{
    Task AddEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<EmailSummaryViewModel> GetEmailsAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}