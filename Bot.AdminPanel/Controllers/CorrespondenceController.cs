﻿using Bot.AdminPanel.ViewModels.Correspondence;
using Bot.Data.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bot.AdminPanel.Controllers {
    [Authorize]
    public class CorrespondenceController : Controller {
        private readonly ILogger<CorrespondenceController> _logger;
        private DataDBContext _dbContext;

        public CorrespondenceController(ILogger<CorrespondenceController> logger, DataDBContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }
        /// <summary>
        /// история сообщений
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() {
            var model = _dbContext.TelegramUpdates.Select(u=>new CorrespondenceViewModelforList(u)).ToList();
            return View(model);
        }
    }
}
