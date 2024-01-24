using Bot.AdminPanel.Identity.Types;
using Microsoft.AspNetCore.Identity;

namespace Bot.AdminPanel.Helpers {
    /// <summary>
    /// Инициализатор ролей
    /// </summary>
    public class RoleInitializer {
        /// <summary>
        /// Инициализировать пользователя поумолчанию superadmin и роль superadmin 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <returns></returns>
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
            string adminEmail = "admin@example.com";
            string adminLogin = "superadmin";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("superadmin") == null) {
                await roleManager.CreateAsync(new IdentityRole("superadmin"));
            }
            if (await userManager.FindByNameAsync(adminLogin) == null) {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminLogin };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(admin, "superadmin");
                }
            }
        }
    }
}
