using AMBUS.Application.Abstraction;
using AMBUS.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Infrastructure.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _emailSettings;

        public EmailService(IOptions<EmailSetting> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmail(string toEmail, string subject, string body)
        {
            var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
       
    }
}
