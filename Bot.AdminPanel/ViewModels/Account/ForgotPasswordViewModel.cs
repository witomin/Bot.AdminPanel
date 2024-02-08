using System.ComponentModel.DataAnnotations;

namespace Bot.AdminPanel.ViewModels.Account {
    public class ForgotPasswordViewModel {
        [EmailAddress]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Email { get; set; }
    }
}
