using System.ComponentModel.DataAnnotations;

namespace Bot.AdminPanel.ViewModels.Users {
    public class ChangePasswordViewModel {
        public string Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
