using Business.Concrete;
using CaptchaMvc.HtmlHelpers;
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

        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());

        // GET: WriterLogin
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var results = wlm.GetWriter(writer.WriterMail, writer.WriterPassword);

            if (results != null)
            {
                if (!this.IsCaptchaValid(""))
                {
                    ViewBag.ErrorMessage = "Captcha geçerli değil";
                    return RedirectToAction("WriterLogin");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(results.WriterMail, false);
                    Session["WriterMail"] = results.WriterMail;
                    return RedirectToAction("MyContent", "WriterContent");
                }
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
      
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("DefaultHeadings", "Default");
        }
    }
}