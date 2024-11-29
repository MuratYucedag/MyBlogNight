using Microsoft.AspNetCore.Mvc;
using MyBlogNight.BusinessLayer.Abstract;

namespace MyBlogNight.PresentationLayer.ViewComponents
{
    public class _CommentListByArticleIdComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;
        public _CommentListByArticleIdComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _commentService.TGetCommentsByArticleId(1);
            return View(values);
        }
    }
}