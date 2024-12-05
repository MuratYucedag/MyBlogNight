using Microsoft.EntityFrameworkCore;
using MyBlogNight.DataAccessLayer.Abstract;
using MyBlogNight.DataAccessLayer.Context;
using MyBlogNight.DataAccessLayer.Repositories;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EfCommentDal(BlogContext context) : base(context)
        {
        }

        public List<Comment> GetCommentsByAppUserId(int id)
        {
            var context = new BlogContext();
            var values=context.Comments.Where(x=>x.AppUserId==id).ToList();
            return values;
        }

        public List<Comment> GetCommentsByArticleId(int id)
        {
            var context = new BlogContext();
            var values = context.Comments.Where(x => x.ArticleId == id).Include(y => y.AppUser).ToList();
            return values;
        }
    }
}