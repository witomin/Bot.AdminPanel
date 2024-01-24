using Bot.AdminPanel.Data.Types;
using Microsoft.EntityFrameworkCore;

namespace tools.niap.ru.Data {
    public class DataDBContext : DbContext {
        /// <summary>
        /// Подписчики
        /// </summary>
        public DbSet<Subscriber> Subscribers { get; set; }

        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options) {
        }
    }
}
