using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.PresentationLayer.Models;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
    }
}
/*
//50 Derste Mvc
//50 Derste Tatil Seyahat Sitesi
//Mvc5 Admin Panelli Cv Sitesi
//Mvc Proje Kampı
//AspNet Core ile Adım Adım Web Geliştirme
*/