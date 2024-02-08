using Microsoft.EntityFrameworkCore;
using Bot.AdminPanel.Data.Types;

namespace Bot.AdminPanel.Data {
    public class DataDBContext : DbContext {
        /// <summary>
        /// Подписчики
        /// </summary>
        public DbSet<Subscriber> Subscribers { get; set; }
        /// <summary>
        /// Поступившие в бот Telegram Updates
        /// </summary>
        public DbSet<TelegramUpdate> TelegramUpdates { get; set; }
        /// <summary>
        /// Запланированные сообщения для пользователей
        /// </summary>
        public DbSet<ScheduledMessage> ScheduledMessages { get; set; }

        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options) {
        }
    }
}
