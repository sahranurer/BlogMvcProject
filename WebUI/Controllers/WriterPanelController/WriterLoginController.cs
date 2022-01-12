using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebUI.Controllers.WriterPanelController
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {
        // GET: WriterLogin
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            WriterManager wm = new WriterManager(new EfWriterDal());
            var results = wm.GetWriters().FirstOrDefault(x=>x.WriterMail==writer.WriterMail && x.WriterPassword==writer.WriterPassword);
            if (results != null)
            {
                FormsAuthentication.SetAuthCookie(results.WriterMail, false);
                Session["WriterMail"] = results.WriterMail;
                return RedirectToAction("MyContent", "WriterContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
    }
}