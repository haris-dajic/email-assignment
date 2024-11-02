using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmailServices;

public class EmailRepository: IEmailRepository
{
    private readonly IApplicationDbContext _dbContext;

    public EmailRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
       await _dbContext.Emails.AddAsync(email, cancellationToken);
       await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<EmailSummaryViewModel> GetEmailsAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var emails =  await _dbContext.Emails.Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new EmailSummaryViewModel()
        {
            Emails = emails.Select(e => (EmailViewModel)e).ToList(),
            PaginationInfo = new PaginationInfo(page, pageSize, _dbContext.Emails.Count())
        };
    }
}