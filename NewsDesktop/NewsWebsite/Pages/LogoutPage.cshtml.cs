using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewsWebsite.Pages
{
    [Authorize]
    public class LogoutPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogout()
        {
            if (HttpContext.User.Identity?.IsAuthenticated == true)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return LocalRedirect("/Index");
        }

        public IActionResult OnPostNo()
        {
            return LocalRedirect(ReturnUrl ?? "/Index");
        }
    }
}
