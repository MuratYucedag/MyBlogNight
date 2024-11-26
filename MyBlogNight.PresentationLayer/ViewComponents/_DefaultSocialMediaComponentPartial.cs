using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _DefaultSocialMediaComponentPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;
        public _DefaultSocialMediaComponentPartial(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _socialMediaService.TGetAll();
            return View(values);
        }
    }
}
