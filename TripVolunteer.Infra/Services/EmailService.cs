using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MailKit.Security;
public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //public void SendEmail(string toEmail, string subject, string body, byte[] attachmentBytes, string attachmentFileName)
    //{
    //    var smtpServer = _configuration["SmtpSettings:Server"];
    //    var port = _configuration["SmtpSettings:Port"];
    //    var username = _configuration["SmtpSettings:Username"];
    //    var password = _configuration["SmtpSettings:Password"];
    //    var senderEmail = _configuration["SmtpSettings:SenderEmail"];

    //    if (string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(port) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    //    {
    //        throw new Exception("SMTP settings are missing or incorrect in appsettings.json");
    //    }

    //    var smtpClient = new SmtpClient("smtp.gmail.com")
    //    {
    //        Port = 587,
    //        Credentials = new NetworkCredential(username, password),
    //        EnableSsl = true,
    //        UseDefaultCredentials = false
    //    };


    //    var mailMessage = new MailMessage
    //    {
    //        From = new MailAddress(senderEmail),
    //        Subject = subject,
    //        Body = body,
    //        IsBodyHtml = true
    //    };

    //    mailMessage.To.Add(toEmail);

    //    // إضافة المرفق إذا كان موجودًا
    //    if (attachmentBytes != null && !string.IsNullOrEmpty(attachmentFileName))
    //    {
    //        var attachment = new Attachment(new MemoryStream(attachmentBytes), attachmentFileName, "application/pdf");
    //        mailMessage.Attachments.Add(attachment);
    //    }

    //    smtpClient.Send(mailMessage);
    //}
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
