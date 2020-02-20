using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServerApp.DataAccess;

namespace ServerApp.Controllers
{
    public class BankomatController : Controller
    {
        private readonly SqlDbContext context;

        public BankomatController(SqlDbContext context)
        {
            this.context = context;
        }

        [Route("bankomat")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("bankomat")]
        public async Task<IActionResult> Index(string id)
        {
            if (context.Cards.Any(x => x.CardNumber == id))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, id)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return View();
            }

            return View(nameof(Index), "Карты с такими данными не существует.");
        }

        [HttpPost]
        [Route("bankomat/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}