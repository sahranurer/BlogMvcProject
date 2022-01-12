using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.WriterPanelController
{
    public class WriterContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterContent
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writerinfo = wm.GetWriters().Where(x => x.WriterMail == p).Select(y=>y.WriterId).FirstOrDefault();
            var values = cm.GetContentsByWriter(writerinfo);
            return View(values);
        }
    }
}