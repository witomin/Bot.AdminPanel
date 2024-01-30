using Bot.AdminPanel.Data.Types;
using System.ComponentModel.DataAnnotations;

namespace Bot.AdminPanel.ViewModels.Subscribers {
    public class SubscriberViewModelforEdit {
        public SubscriberViewModelforEdit() { }
        public SubscriberViewModelforEdit(Subscriber subscriber) {
            Id = subscriber.Id;
            Username = subscriber.Username;
            DisplayName = subscriber.DisplayName;
            City = subscriber.City;
            Social = subscriber.Social;
            Phone = subscriber.Phone;
            Confirmed = subscriber.Confirmed;
            Created = subscriber.Created;
        }
        [Display(Name = "ТГ ID")]
        public long Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        public string? Username { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        [Display(Name = "ФИО")]
        public string? DisplayName { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        [Display(Name = "Город")]
        public string? City { get; set; }
        /// <summary>
        /// Соц. сети
        /// </summary>
        [Display(Name = "Соц. сети")]
        public string? Social { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }
        /// <summary>
        /// Признак Подтвержден/Не подтвержден
        /// </summary>
        [Display(Name = "Активен")]
        public bool Confirmed { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        [Display(Name = "Дата регистрации")]
        public DateTime? Created { get; set; }
    }
}
