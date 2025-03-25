using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MailKit.Security;
using TripVolunteer.Core.Services;
public class EmailService: IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {


        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("plain") { Text = message };
        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            client.ServerCertificateValidationCallback = (s, c, h, e) => true; // Optional: For debugging TLS issues
            client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
            client.Authenticate("raghood.allouzi96@gmail.com", "ihqdausxmitfhqgs");

            //await client.ConnectAsync(_configuration["SmtpSettings:Server"], int.Parse(_configuration["SmtpSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
            //await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
    public async Task SendEmailWithPDFAsync(string toEmail, string subject, string message, byte[] pdfInvoice)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Manager", _configuration["SmtpSettings:SenderEmail"]));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = message,
            TextBody = message
        };

        bodyBuilder.Attachments.Add("invoice.pdf", pdfInvoice, new ContentType("application", "pdf"));
        emailMessage.Body = bodyBuilder.ToMessageBody();

        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
            await client.AuthenticateAsync("raghood.allouzi96@gmail.com", "ihqdausxmitfhqgs");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
