using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Bot.AdminPanel.Identity.Types;
using Bot.AdminPanel.ViewModels.Account;
using Bot.AdminPanel.ViewModels.Users;
using Bot.AdminPanel.Mail;

namespace Bot.AdminPanel.Controllers {
    public class AccountController : Controller {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        UserManager<ApplicationUser> _userManager;
        private MailService _mailService;

        public AccountController(SignInManager<ApplicationUser> signInManager, 
            MailService mailService, 
            UserManager<ApplicationUser> userManager, 
            ILogger<AccountController> logger) {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _mailService = mailService;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null) {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded) {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl)) {
                        return Redirect(model.ReturnUrl);
                    }
                    else {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword() {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model) {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null) {
                    // пользователь с данным email может отсутствовать в бд
                    // тем не менее мы выводим стандартное сообщение, чтобы скрыть 
                    // наличие или отсутствие пользователя в бд
                    return View("ForgotPasswordConfirmation", model);
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await _mailService.SendEmailAsync(model.Email, "Сброс пароля",
                    $"Для сброса пароля пройдите по <a href='{callbackUrl}'>ссылке</a>");
                return View("ForgotPasswordConfirmation", model);
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string code) {
            if (string.IsNullOrEmpty(code)|| string.IsNullOrEmpty(userId)) {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.userId);
            if (user == null) {
                return View("ResetPasswordConfirmation");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded) {
                return View("ResetPasswordConfirmation");
            }
            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        public IActionResult Index() {
            return View();
        }
        public IActionResult AccessDenied() {
            return View();
        }
    }
}
