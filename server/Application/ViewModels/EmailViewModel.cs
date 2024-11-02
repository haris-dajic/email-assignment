using Domain.Entities;

namespace Application.ViewModels;

public class EmailViewModel
{
    public string Content { get; set; }
    public string FromEmail { get; set; }
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public IList<string> CCEmails { get; set; }

    public static implicit operator EmailViewModel(Email email)
    {
        return new EmailViewModel
        {
            Content = email.Content,
            FromEmail = email.FromEmail,
            ToEmail = email.ToEmail,
            Subject = email.Subject,
            CCEmails = email.CCEmails.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
        };
    }
}