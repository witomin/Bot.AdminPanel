using Bot.Data.Core.Types;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;

namespace Bot.AdminPanel.ViewModels.Correspondence {
    public class CorrespondenceViewModelforList {
        private Update? update;
        private Message? replyMessage;
        public CorrespondenceViewModelforList(TelegramUpdate telegramUpdate) {
            update = JsonConvert.DeserializeObject<Update>(telegramUpdate?.Update);
            replyMessage = JsonConvert.DeserializeObject<Message>(telegramUpdate?.ReplyMessageContent);

            Id = telegramUpdate.Id;
            ReceivedTime = telegramUpdate.ReceivedTime;
            From = update?.Message?.From?.ToString() ?? update?.CallbackQuery?.From?.ToString();
            Message = $"{update?.Type}: {update?.Message?.Text ?? update?.CallbackQuery?.Data}";
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
