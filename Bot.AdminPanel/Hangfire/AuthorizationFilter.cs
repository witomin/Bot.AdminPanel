using Hangfire.Dashboard;

namespace Bot.AdminPanel.Hangfire {
    public class AuthorizationFilter : IDashboardAuthorizationFilter {
        public bool Authorize(DashboardContext context) {
            var httpContext = context.GetHttpContext();
            if (httpContext.User.Identity == null) return false;
            return httpContext.User.IsInRole("superadmin");
        }
    }
}
