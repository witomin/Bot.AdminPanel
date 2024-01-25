using Bot.AdminPanel.ViewModels.Subscribers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tools.niap.ru.Data;

namespace Bot.AdminPanel.Controllers {
    [Authorize]
    public class SubscribersController : Controller {

        private readonly ILogger<SubscribersController> _logger;
        private DataDBContext _dbContext;

        public SubscribersController(ILogger<SubscribersController> logger, DataDBContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }
        /// <summary>
        /// Список подписчиков
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() {
            var model = _dbContext.Subscribers.Select(s => new SubscriberViewModelforList(s)).ToList();
            return View(model);
        }
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(string id) {
            var subscriber = _dbContext.Subscribers.SingleOrDefaultAsync(s => s.Id.ToString().Equals(id));
            if (subscriber != null) {
                _dbContext.Subscribers.Remove(await subscriber);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Редактировать
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(string id) {
            var subscriber = _dbContext.Subscribers.SingleOrDefaultAsync(s => s.Id.ToString().Equals(id));
            if (subscriber != null) {
                return View(new SubscriberViewModelforEdit(await subscriber));
            }
            return NotFound();
        }
        /// <summary>
        /// Редактировать
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(SubscriberViewModelforEdit model) {
            if (ModelState.IsValid) {
                var subscriber = await _dbContext.Subscribers.SingleOrDefaultAsync(s => s.Id.Equals(model.Id));
                if (subscriber != null) {
                    subscriber.DisplayName = model.DisplayName;
                    subscriber.City = model.City;
                    subscriber.Social = model.Social;
                    subscriber.Phone = model.Phone;
                    subscriber.Confirmed = model.Confirmed;
                    await _dbContext.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
