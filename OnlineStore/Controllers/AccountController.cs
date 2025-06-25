using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserAuthViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    CreatedAt = DateTime.UtcNow
                };

                _userService.Register(user);
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserAuthViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetByEmailAndPassword(model.Email, model.Password);
                if (user != null)
                {
                    TempData["WelcomeMessage"] = $"Добро пожаловать, {user.Name}!";
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Неверный email или пароль.");
            }

            return View(model);
        }
    }
}
