using System.ComponentModel.DataAnnotations;

namespace Bot.AdminPanel.ViewModels.Users {
    public class EditUserViewModel {
        public string Id { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        [Display(Name = "Имя")]
        public string SecondName { get; set; }
        [Display(Name = "Отчество")]
        public string ThirdName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Email { get; set; }
        [Display(Name = "Аватар")]
        public string? AvatarUrl { get; set; }
    }
}
