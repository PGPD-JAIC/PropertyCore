using Hangfire.Dashboard;

namespace PropertyCore.WebUI.Filters
{
    /// <summary>
    /// Implementation of <see cref="IDashboardAsyncAuthorizationFilter"/>
    /// </summary>
    public class HangfireDashAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            return httpContext.User.IsInRole("Admin");
        }
    }
}
