using System.ComponentModel.DataAnnotations;

namespace Bot.AdminPanel.ViewModels.Users {
    public class LoginViewModel {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
