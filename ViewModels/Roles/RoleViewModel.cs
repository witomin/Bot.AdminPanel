using System.ComponentModel.DataAnnotations;

namespace Bot.AdminPanel.ViewModels.Roles {
    public class RoleViewModel
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование роли
        /// </summary>
        [Display(Name = "Наименование роли")]
        public string Name { get; set; }

        /// <summary>
        /// Описание роли
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
