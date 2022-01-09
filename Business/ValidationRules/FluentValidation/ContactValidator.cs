using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {

        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Lütfen email alanını giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen isim alanını boş bırakmayınız.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen subject alanını boş bırakmayınız.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu alanı en az 5 karakterli olmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Konu alanı en çok 20 karakterli olmalıdır.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Lütfen mesaj alanını boş bırakmayınız.");
            RuleFor(x => x.Message).MinimumLength(5).WithMessage("Mesaj alanını en az 5  karakterli olmalıdır.");
            RuleFor(x => x.Message).MaximumLength(30).WithMessage("Mesaj alanını en çok 30" +
                "  karakterli olmalıdır.");

        }

    }
}
