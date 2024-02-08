using System.ComponentModel.DataAnnotations.Schema;

namespace Bot.Data.Core.Types {
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
        /// Telegram Update
        /// </summary>
        public string? Update { get; set; }     
        /// <summary>
        /// Ответное сообщение
        /// </summary>
        public string? ReplyMessageContent { get; set; }
    }
}
