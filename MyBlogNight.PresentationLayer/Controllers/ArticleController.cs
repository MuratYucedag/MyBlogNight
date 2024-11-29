using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogNight.BusinessLayer.Abstract;
using MyBlogNight.EntityLayer.Concrete;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public IActionResult ArticleList()
        {
            var values = _articleService.TArticleListWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            var categoryList = _categoryService.TGetAll();
            List<SelectListItem> values1 = (from x in categoryList
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;
            return View();
        }

        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("ArticleList");
        }

        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("ArticleList");
        }
        public IActionResult ArticleDetail(int id)
        {
            _articleService.TArticleViewCountIncrease(id);

            var value = _articleService.TArticleListWithCategoryAndAppUserByArticleId(id);
            return View(value);
        }
    }
}
