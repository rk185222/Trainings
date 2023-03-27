using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Pages
{
    public class LogoutIDPModel : PageModel
    {
        public async Task OnPostAsync()
        {
            await HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext
                .SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

        }
    }
}
