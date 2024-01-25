using Bot.AdminPanel.Data.Types;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;

namespace Bot.AdminPanel.ViewModels.Correspondence {
    public class CorrespondenceViewModelforList {
        private Message? message;
        private Message? replyMessage;
        public CorrespondenceViewModelforList(TelegramUpdate telegramUpdate) {
            message = System.Text.Json.JsonSerializer.Deserialize<Message>(telegramUpdate?.MessageContent);
            replyMessage = System.Text.Json.JsonSerializer.Deserialize<Message>(telegramUpdate?.ReplyMessageContent);

            Id = telegramUpdate.Id;
            ReceivedTime = telegramUpdate.ReceivedTime;
            From = message?.From?.ToString();
            Message = $"{message?.Type}: {message?.Text}";
            ReplyMessage = $"{replyMessage?.Type}: {replyMessage?.Text}";

        }
        public Guid Id { get; set; }
        /// <summary>
        /// Получено
        /// </summary>
        [Display(Name = "Получено")]
        public DateTime ReceivedTime { get; set; }
        /// <summary>
        /// Получено от
        /// </summary>
        [Display(Name = "От")]
        public string? From { get; set; }
        /// <summary>
        /// Сообщение
        /// </summary>
        [Display(Name = "Сообщение")]
        public string? Message { get; set; }
        /// <summary>
        /// Ответ бота
        /// </summary>
        [Display(Name = "Ответ бота")]
        public string? ReplyMessage { get; set; }

    }
}
