using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz.");
            RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage("En az iki karakter giriniz.");
        }
    }
}
