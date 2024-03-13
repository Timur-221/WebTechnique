using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebTechnique.DBase;

namespace WebTechnique.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataBase _dataBase;

        public AccountController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            var account = _dataBase.Accounts.Where(x => x.Login == username && x.Password == password).FirstOrDefault();

            if (account != null)
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, username),
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }


            // Если аутентификация не удалась, возвращаем пользователя на страницу входа с сообщением об ошибке
            ViewBag.ErrorMessage = "Нет такого пользователя";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
