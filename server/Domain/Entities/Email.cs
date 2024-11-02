using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Email: BaseEntity
{
    public string Content { get; set; }
    public string FromEmail { get; set; }
    public string ToEmail { get; set; }
    public string CCEmails { get; set; } //Emails separated by semi column
    public string Subject { get; set; }
    public EmailImportance Importance { get; set; }
}