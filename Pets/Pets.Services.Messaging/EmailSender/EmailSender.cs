using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pets.Common.Settings;

namespace Pets.Services.Messaging
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger logger;
        private EmailSettings settings;

        public EmailSender(ILoggerFactory loggerFactory, IOptions<EmailSettings> settings)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            this.logger = loggerFactory.CreateLogger<EmailSender>();
            this.settings = settings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            if (string.IsNullOrWhiteSpace(this.settings.FromEmail))
            {
                throw new ArgumentOutOfRangeException(nameof(this.settings.FromEmail));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentOutOfRangeException(nameof(email));
            }

            if (string.IsNullOrWhiteSpace(subject) && string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Subject and/or message must be provided.");
            }

            try
            {
                using (var emailForSending = new MailMessage())
                {
                    emailForSending.To.Add(new MailAddress(email, "Pets Team"));
                    emailForSending.From = new MailAddress(this.settings.FromEmail);
                    emailForSending.Subject = subject;
                    emailForSending.Body = message;
                    emailForSending.IsBodyHtml = true;

                    using (var client = new SmtpClient(this.settings.Domain))
                    {
                        client.Port = this.settings.Port;
                        client.Credentials = new NetworkCredential(this.settings.Username, this.settings.Password);
                        client.EnableSsl = true;
                        client.Send(emailForSending);
                    }
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Exception during sending email: {ex}");
            }

            return Task.FromResult(true);
        }
    }
}
