using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebTechnique.DBase;
using WebTechnique.MyClass;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            var hasPassword = new HasPassword();
            hasPassword.PasswordHash = password;

            var account = _dataBase.Accounts
             .Include(a => a.PersonToRole)
             .ThenInclude(ptr => ptr.Role)
             .FirstOrDefault(x => x.Login == username && x.Password == hasPassword.PasswordHash);

            if (account != null )
            {
                var claims = new[]
                {
                  new Claim(ClaimTypes.Name, account.Login),
                  new Claim(ClaimTypes.Role, account.PersonToRole.Role.Name),
                  new Claim(ClaimTypes.Authentication, account.PersonToRole.PersonId.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            // Если аутентификация не удалась, перенаправляем пользователя на страницу входа с сообщением об ошибке
            ViewBag.ErrorMessage = "Неверное имя пользователя или пароль";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
