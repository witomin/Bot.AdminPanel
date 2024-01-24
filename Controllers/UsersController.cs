using Bot.AdminPanel.Identity.Types;
using Bot.AdminPanel.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bot.AdminPanel.Controllers {
    [Authorize]
    public class UsersController : Controller {
        IWebHostEnvironment _appEnvironment;
        UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UserManager<ApplicationUser> userManager, IWebHostEnvironment appEnvironment, ILogger<UsersController> logger) {
            _userManager = userManager;
            _appEnvironment = appEnvironment;
            _logger = logger;
        }
        [Authorize(Roles = "superadmin")]
        public IActionResult Index() {
            return View(_userManager.Users.ToList());
        }

        [Authorize(Roles = "superadmin")]
        public IActionResult Create() => View();

        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model) {
            if (ModelState.IsValid) {
                ApplicationUser user = new ApplicationUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    _logger.LogInformation($"{User.Identity.Name} created new application user {model.UserName}");
                    return RedirectToAction("Index");
                }
                else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Edit(string id) {
            var idUser = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(id)) {
                id = idUser;
            }
            if (!User.IsInRole("superadmin") && !idUser.Equals(id)) {
                return Forbid();
            }

            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user == null) {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                ThirdName = user.ThirdName,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl
            };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model) {
            if (ModelState.IsValid) {
                var idUser = _userManager.GetUserId(User);
                if (!User.IsInRole("superadmin") && !idUser.Equals(model.Id)) {
                    return Forbid();
                }
                ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null) {
                    if (User.IsInRole("superadmin")) {
                        user.UserName = model.UserName;
                    }
                    user.FirstName = model.FirstName;
                    user.SecondName = model.SecondName;
                    user.ThirdName = model.ThirdName;
                    user.Email = model.Email;
                    user.AvatarUrl = model.AvatarUrl;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded) {
                        _logger.LogInformation($"{User.Identity.Name} edited application user {model.UserName}");
                        return Redirect(Request.Headers["Referer"].ToString());
                    }
                    else {
                        foreach (var error in result.Errors) {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<ActionResult> Delete(string id) {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user != null) {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) {
                    _logger.LogInformation($"{User.Identity.Name} deleted application user {user.UserName}");
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ChangePassword(string id) {
            var idUser = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(id)) {
                id = idUser;
            }
            if (!User.IsInRole("superadmin") && !idUser.Equals(id)) {
                return Forbid();
            }
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user == null) {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, UserName = user.UserName };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model) {
            if (ModelState.IsValid) {
                var idUser = _userManager.GetUserId(User);
                if (!User.IsInRole("superadmin") && !idUser.Equals(model.Id)) {
                    return Forbid();
                }
                ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null) {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<ApplicationUser>)) as IPasswordValidator<ApplicationUser>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<ApplicationUser>)) as IPasswordHasher<ApplicationUser>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded) {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return Redirect(Request.Headers["Referer"].ToString());
                    }
                    else {
                        foreach (var error in result.Errors) {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Avatar(string id) {
            if (string.IsNullOrEmpty(id)) {
                id = _userManager.GetUserId(User);
            }
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user == null) {
                user = await _userManager.FindByNameAsync(id);
                if (user == null) {
                    return NotFound();
                }
            }
            if (user.Avatar==null) {
                var file = Path.Combine(_appEnvironment.WebRootPath, "img", "avatarEmpty.png");
                return PhysicalFile(file, "image/png");
            }
            else {
                return File(user.Avatar, "image/png");
            }
        }

        [HttpPost]
        public async Task<ActionResult> LoadAvatar(string id, IFormFile avatarFile) {
            if (avatarFile != null) {
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                if (user == null) {
                    return NotFound();
                }
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(avatarFile.OpenReadStream())) {
                    imageData = binaryReader.ReadBytes((int)avatarFile.Length);
                }
                user.Avatar = imageData;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded) {
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
