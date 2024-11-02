using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Domain.Commands;
using Domain.Common;
using Domain.Entities;

namespace Application.Domain.Handlers;

public class SendEmailCommandHandler: CommandHandler<SendEmailCommand, ApiResult>
{
    private readonly IEmailRepository _emailRepository;

    public SendEmailCommandHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public override async Task<ApiResult> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        await _emailRepository.AddEmailAsync(request, cancellationToken);
        return ApiResult.Success();
    }
}