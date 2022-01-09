using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı alanı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konuyu alanı en az 3 karakterli olmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(30).WithMessage("Konuyu alanı en çok 30 karakterli olmalıdır.");
            RuleFor(x => x.ReceiverMail).Must(IsMailValid).WithMessage("Lütfen e-mail formatında giriniz.");
        }
        private bool IsMailValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
