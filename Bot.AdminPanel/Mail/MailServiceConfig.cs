using MailKit.Security;

namespace Bot.AdminPanel.Mail {
    /// <summary>
    /// Конфигурация SMTP сервера
    /// </summary>
    public class MailServiceConfig
    {
        /// <summary>
        /// Адрес сервера SMTP
        /// </summary>
        public string SmtpServerAddress { get; set; }
        /// <summary>
        /// Порт SMTP
        /// </summary>
        public int SmtpPort { get; set; }
        /// <summary>
        /// Опции SSL
        /// </summary>
        public SecureSocketOptions SSLOption { get; set; }
        /// <summary>
        /// Логин SMTP
        /// </summary>
        public string SmtpLogin { get; set; }
        /// <summary>
        /// Пароль SMTP
        /// </summary>
        public string SmtpPassword { get; set; }
        /// <summary>
        /// От кого
        /// </summary>
        public string SmtpFromName { get; set; }

    }
}
