using System.ComponentModel.DataAnnotations;

namespace Bot.AdminPanel.ViewModels.Account {
    public class ResetPasswordViewModel {
        public string userId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
