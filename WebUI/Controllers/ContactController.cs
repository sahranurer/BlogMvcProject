using Business.Concrete;
using Business.ValidationRules.FluentValidation;
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
        ContactValidator cv = new ContactValidator();
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
            return PartialView();
        }

        public PartialViewResult ContactPartialDiger()
        {
            return PartialView();
        }



    }
}