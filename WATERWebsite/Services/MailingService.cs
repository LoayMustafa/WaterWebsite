using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Runtime.CompilerServices;
using WATERWebsite.Settings;

namespace WATERWebsite.Services
{
    public class MailingService : IMailingService
    {
        private readonly MailSettings _mailSettings;
        public MailingService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(string mailTo, string mailFrom, string clientName, string clientNumber, string subject, string body, IList<IFormFile>? attachments)
        {
            try
            {

                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_mailSettings.Email),
                    Subject = subject,
                };
                email.To.Add(MailboxAddress.Parse(mailTo));
                var builder = new BodyBuilder();

                if (attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in attachments)
                    {
                        if (file.Length > 0)
                        {
                            using var ms = new MemoryStream();
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }

                    };
                }

                string emailBody = $"You Have New Contact : \n" +
                            $"Email : {mailFrom}\n" +
                            $"Client Name : {clientName} \n" +
                            $"Client Number : {clientNumber} \n" +
                            $"Contact Message : \n {body} \n";

                emailBody = emailBody.Replace("\n", "<br />");

                builder.HtmlBody = emailBody;
                email.Body = builder.ToMessageBody();
                email.From.Add(new MailboxAddress("New Contact", _mailSettings.Email));
                using var smtp = new SmtpClient();


                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
                await smtp.SendAsync(email);

                smtp.Disconnect(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
