using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!(Email == "rk185222@ncr.com" && Password == "password"))
            {
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "rk185222"),
                new Claim(ClaimTypes.Email, Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(Url.Content("~/"));
        }
    }
}
