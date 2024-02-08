using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bot.AdminPanel.Identity.Types;

namespace Bot.AdminPanel.Identity {
    public class ApplicationIdentityDbContext: IdentityDbContext<ApplicationUser> {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) {
        }
    }
}
