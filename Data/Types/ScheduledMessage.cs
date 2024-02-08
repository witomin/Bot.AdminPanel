using System.ComponentModel.DataAnnotations.Schema;

namespace Bot.AdminPanel.Data.Types {
    /// <summary>
    /// Запланированное сообщение
    /// </summary>
    public class ScheduledMessage {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор подписчика
        /// </summary>
        public long SubscriberId { get; set; }
        /// <summary>
        /// Идентификатор телеграм чата
        /// </summary>
        public long ChatId { get; set; }  
        /// <summary>
        /// Периодмчность
        /// </summary>
        public string Periodicity { get; set; }
        /// <summary>
        /// Тип сообщений
        /// </summary>
        public string MessageType {  get; set; }

    }
}
