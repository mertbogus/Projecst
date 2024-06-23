using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EntityLayer.Concrete;
namespace Projects.Models
{
    public class AdminAuthorizeAttribute : TypeFilterAttribute
    {
        public AdminAuthorizeAttribute() : base(typeof(AdminAuthorizeFilter))
        {
        }

        private class AdminAuthorizeFilter : IAsyncActionFilter
        {
            private readonly UserManager<AppUser> userManager;

            public AdminAuthorizeFilter(UserManager<AppUser> userManager)
            {
                this.userManager = userManager;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var user = await userManager.GetUserAsync(context.HttpContext.User);
                if (user != null)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        await next();
                        return;
                    }
                }

                // Kullanıcı Admin değilse, AccessDenied sayfasına yönlendir.
                context.Result = new RedirectToActionResult("AccessDenied", "Login", new { area = "" });
            }
        }
    }
}
