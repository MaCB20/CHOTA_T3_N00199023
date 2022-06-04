using CHOTA_T3.WEB.BD;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CHOTA_T3.WEB.Controllers
{
    public class AuthController : Controller
    {
        private DbEntities _DbEntities;
        public AuthController(DbEntities dbEntities)
        {
            _DbEntities = dbEntities;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_DbEntities.usuarios.Any(x => x.Username == username && x.Passowrd == password))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("AuthError", "Usuario y/o contraseña incorrectos");
            return View();
            
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
