using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        Context _context = new Context();
       
        public ActionResult Index()
        {
            var results = cm.GetContacts();
            return View(results);
        }

        public ActionResult GetContactDetails(int id)
        {
            var values = cm.GetbyId(id);
            return View(values);
        }

        public PartialViewResult ContactPartial()
        {
            var results = cm.GetContacts().Count();
            ViewBag.contact = results;

            var receiverMail = _context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com").ToString();
            ViewBag.receiverMail = receiverMail;

            var sendMail = _context.Messages.Count(x => x.SenderMail == "admin@gmail.com").ToString();
            ViewBag.send = sendMail;

            var draftMail = _context.Messages.Count(x => x.isDraft == true);
            ViewBag.draft = draftMail;

            return PartialView();
        }

        public PartialViewResult ContactPartialDiger()
        {
            return PartialView();
        }

        public ActionResult IsRead(int id) //Bu alan sistem mesajlarindaki okundu butonundan gelen degeri DB yazar
        {
            var contactValue = cm.GetbyId(id);

            if (contactValue.IsRead)
            {
                contactValue.IsRead = false;
            }
            else
            {
                contactValue.IsRead = true;
            }

            cm.Update(contactValue);
            return RedirectToAction("Index");
        }


        public ActionResult IsImportant(int id) //Bu alan sistem mesajlarindaki önemli butonundan gelen degeri DB yazar
        {
            var contactValue = cm.GetbyId(id);

            if (contactValue.IsImportant)
            {
                contactValue.IsImportant = false;
            }
            else
            {
                contactValue.IsImportant = true;
            }

            cm.Update(contactValue);
            return RedirectToAction("Index");
        }



    }
}