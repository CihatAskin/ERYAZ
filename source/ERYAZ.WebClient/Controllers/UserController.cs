using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ERYAZ.WebClient.Models.User;
using Microsoft.Extensions.Options;

namespace ERYAZ.WebClient.Controllers
{
    public class UserController : BaseController
    {
        private IOptions<LogOnModel> _user;

        public UserController(IOptions<LogOnModel> user)
        {
            _user = user;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult LogOn()
        {
            return View(new LogOnModel());
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> LogOn(LogOnModel model)
        {
            try
            {
                var user = _user.Value.User;
                var pass = _user.Value.Pass;

                if (model.User != user
                    || model.Pass != pass)
                {
                    model.ErrorMessage.Add("kullanıcı adı şifre ile giriş yapılamadı!");
                    return View(model);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            }
            catch (Exception e)
            {
                model.ErrorMessage.Add(e.Message);
                return View(model);
            }

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public async Task<RedirectResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
