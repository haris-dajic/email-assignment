using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Email> Emails { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}