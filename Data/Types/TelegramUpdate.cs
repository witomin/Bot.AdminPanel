using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.Enums;

namespace Bot.AdminPanel.Data.Types {
    /// <summary>
    /// Telegram Update
    /// </summary>
    public class TelegramUpdate {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Время получения Update
        /// </summary>
        public DateTime ReceivedTime { get; set; }
        /// <summary>
        /// Уникальный идентификатор Telegram Update
        /// </summary>
        public int TelegramUpdateId { get; set; }
        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        public string? MessageContent { get; set; }     
        /// <summary>
        /// Ответное сообщение
        /// </summary>
        public string? ReplyMessageContent { get; set; }
        /// <summary>
        /// Тип Update
        /// </summary>
        public UpdateType Type { get; set; }
    }
}
