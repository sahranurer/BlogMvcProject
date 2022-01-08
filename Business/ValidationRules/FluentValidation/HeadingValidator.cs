using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.WriterId).NotEmpty().WithMessage("Yazar alanı boş geçilemez");
            //RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Date alanı boş bırakılamaz");
        }
    }
}
