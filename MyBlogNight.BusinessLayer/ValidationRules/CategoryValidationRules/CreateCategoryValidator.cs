using FluentValidation;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.BusinessLayer.ValidationRules.CategoryValidationRules
{
    public class CreateCategoryValidator : AbstractValidator<Category>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Lütfen kategori adını boş bırakmayınız!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız!");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız!");
        }
    }
}
