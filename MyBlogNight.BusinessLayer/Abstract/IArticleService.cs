using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        public List<Article> TArticleListWithCategory();
        public List<Article> TArticleListWithCategoryAndAppUser();
        public Article TArticleListWithCategoryAndAppUserByArticleId(int id);
        public void TArticleViewCountIncrease(int id);
        public List<Article> TGetArticlesByAppUserId(int id);
    }
}
