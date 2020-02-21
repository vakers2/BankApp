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

        [Route("bankomat/success")]
        public IActionResult Success()
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

                return RedirectToAction(nameof(Index));
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

        [Route("bankomat/status")]
        public IActionResult Status()
        {
            var cardNumber = User.Identity.Name;
            var card = context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
            return View(card?.CardBalance);
        }   

        [Route("bankomat/take")]
        public IActionResult Take()
        {
            return View();
        }       
        
        [HttpPost]
        [Route("bankomat/take")]
        public IActionResult Take(int sum)
        {
            var cardNumber = User.Identity.Name;
            var card = context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
            if (sum > card?.CardBalance)
            {
                return View(nameof(Take), "У вас недостаточно средств!");
            }

            card.CardBalance -= sum;
            context.Cards.Update(card);
            context.SaveChanges();

            return RedirectToAction(nameof(Success));
        }
    }
}