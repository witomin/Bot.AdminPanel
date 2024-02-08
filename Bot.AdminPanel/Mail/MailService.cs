using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Bot.AdminPanel.Mail {
    public class MailService
    {
        private readonly MailServiceConfig _config;

        public MailService(IOptions<MailServiceConfig> config) {
            _config = config.Value;
        }
        /// <summary>
        /// Отправить Email
        /// </summary>
        /// <param name="email">Адрес назначения</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Текст</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string message) {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_config.SmtpFromName, _config.SmtpLogin));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = message
            };

            using (var client = new SmtpClient()) {
                await client.ConnectAsync(_config.SmtpServerAddress, _config.SmtpPort, _config.SSLOption);
                await client.AuthenticateAsync(_config.SmtpLogin, _config.SmtpPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
