using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Pages
{
    public class LoginIDPModel : PageModel
    {
        public async Task OnGetAsync(string redirectUri)
        {
            if(string.IsNullOrEmpty(redirectUri))
            {
                redirectUri = Url.Content("~/");
            }

            if(HttpContext.User.Identity.IsAuthenticated)
            {
                Response.Redirect(redirectUri);
            }

            await HttpContext.ChallengeAsync(
                OpenIdConnectDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = redirectUri });
        }
    }
}
