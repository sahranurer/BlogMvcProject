using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
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
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail = (string)Session["WriterMail"];
            var writerinfo = wm.GetWriters().Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.WriterId = writerinfo;
            content.ContentStatus = true;
            cm.Add(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }

    }
}