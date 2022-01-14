using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.WriterPanelController
{
    public class WriterPanelController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = wm.GetWriters().Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer w)
        {
           
                wm.Update(w);
                return RedirectToAction("AllHeading","WriterHeading");
            ////}
            ////else
            ////{
            ////    foreach (var item in result.Errors)
            ////    {
            ////        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            ////    }
            ////}
            //return View();
        }
    }
}