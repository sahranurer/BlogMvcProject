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

            return PartialView();
        }

        public PartialViewResult ContactPartialDiger()
        {
            return PartialView();
        }



    }
}