export interface SendEmailRequest {
  fromEmail: string;
  toEmail: string;
  ccEmails: string;
  subject: string;
  importance: number | null;
  content: string | null;
}
