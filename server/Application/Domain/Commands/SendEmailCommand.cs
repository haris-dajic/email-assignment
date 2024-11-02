using Application.Common.Models;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;

namespace Application.Domain.Commands;

public class SendEmailCommand : Command<ApiResult>
{
    public string Content { get; set; }
    public string FromEmail { get; set; }
    public string ToEmail { get; set; }
    public IList<string> CCEmails { get; set; }
    public string Subject { get; set; }
    public EmailImportance Importance { get; set; }
    
    public static implicit operator Email(SendEmailCommand command)
    {
        return new Email
        {
            Id = Guid.NewGuid(),
            Content = command.Content,
            CCEmails = string.Join(";", command.CCEmails),
            FromEmail = command.FromEmail,
            ToEmail = command.ToEmail,
            Subject = command.Subject,
            Importance = command.Importance
        };
    }
}

public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand> 
{
    public SendEmailCommandValidator() 
    {
        RuleFor(x => x.FromEmail).EmailAddress();
        RuleFor(x => x.ToEmail).EmailAddress();
        RuleFor(x => x.Importance).NotNull();
        RuleFor(x => x.CCEmails)
            .ForEach(email => email
                .EmailAddress());
    }
}

