using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace WebUI.Controllers.WriterPanelController
{
    public class WriterHeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        int id;
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
           var writerinfo = wm.GetWriters().Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var results = hm.GetHeadingsByWriter(writerinfo);
            return View(results);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
          
            
            List<SelectListItem> selects = (from x in cm.GetCategories()
                                            select new SelectListItem
                                            {

                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()

                                            }).ToList();
            ViewBag.vlc = selects;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string m = (string)Session["WriterMail"];
            var writerinfo = wm.GetWriters().Where(x => x.WriterMail == m).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerinfo;
            heading.HeadingStatus = true;
            hm.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> selects = (from x in cm.GetCategories()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();



            ViewBag.vlc = selects;
            var values = hm.GetById(id);
            return View(values);
        }

        public ActionResult EditHeading(Heading heading)
        {
            hm.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var results = hm.GetById(id);
            results.HeadingStatus = false;
            hm.Delete(results);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page=1)
        {
            var allheadings = hm.GetHeadings().ToPagedList(page,4);
            return View(allheadings);
        }

    }
}