using Telegram.Bot.Types;

namespace Bot.AdminPanel.Data.Types {
    /// <summary>
    /// Подписчик
    /// </summary>
    public class Subscriber : User {
        /// <summary>
        /// Наименование организации
        /// </summary>
        public string? CompanyName { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string? DisplayName { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// Код города
        /// </summary>
        public int? CityCode { get; set; }
        /// <summary>
        /// Ссылка на социальные сети
        /// </summary>
        public string? Social { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Активен/Заблокирован
        /// </summary>
        public bool Confirmed { get; set; } = true;
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime? Created { get; set; }
        /// <summary>
        /// Запланированные сообщения
        /// </summary>
        public List<ScheduledMessage>? ScheduledMessages { get; set; }
    }
}
