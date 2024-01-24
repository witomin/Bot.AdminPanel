using Bot.AdminPanel.Identity.Types;
using Bot.AdminPanel.ViewModels.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bot.AdminPanel.Controllers {

    [Authorize(Roles = "superadmin")]
    public class RolesController : Controller {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// Описания ролей
        /// </summary>
        Dictionary<string, string> Roles = new Dictionary<string, string>{
            { "superadmin", "Главный администратор приложения."}
        };
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager) {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index() {
            var identityRoles = _roleManager.Roles.ToList();
            var model = identityRoles.Select(r => new RoleViewModel {
                Id = r.Id,
                Name = r.Name,
                Description = Roles.SingleOrDefault(x => x.Key.Equals(r.Name)).Value ?? string.Empty
            });
            return View(model);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name) {
            if (!string.IsNullOrEmpty(name)) {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                }
                else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id) {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null) {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string userId) {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel {
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles) {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("Index", "Users");
            }
            return NotFound();
        }
    }
}
