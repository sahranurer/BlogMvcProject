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
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty();
            RuleFor(x => x.WriterAbout).NotEmpty();
            RuleFor(x => x.WriterMail).Must(IsMailValid).WithMessage("Lütfen e-mail formatında giriniz.");
            //RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Lütfen 8 karakterli şifre girniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Bu kısmı boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında kısmında en az bir defa a harfi kullanılmalıdır");

        }

        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"((?=.\d)(?=.[a-z])(?=.*[A-Z]).{8,})");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {

                return false;
            }
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


        private bool IsAboutValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a,A])");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {

                return false;
            }
        }




    }
}
