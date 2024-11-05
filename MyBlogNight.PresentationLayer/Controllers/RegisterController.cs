using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogNight.EntityLayer.Concrete;
using MyBlogNight.PresentationLayer.Models;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                UserName = model.Username,
                ImageUrl = "test"
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}