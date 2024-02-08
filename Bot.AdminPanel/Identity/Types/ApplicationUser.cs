using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Bot.AdminPanel.Identity.Types {
    /// <summary>
    /// Пользователь
    /// </summary>
    public class ApplicationUser : IdentityUser {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string? SecondName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? ThirdName { get; set; }
        /// <summary>
        /// Аватар
        /// </summary>
        public string? AvatarUrl { get; set; }
        /// <summary>
        /// Аватар
        /// </summary>
        public byte[]? Avatar { get; set; }
    }
}
