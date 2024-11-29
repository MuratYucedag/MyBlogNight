using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Article> Articles { get; set; }
    }
}
//public-private-internal-protected