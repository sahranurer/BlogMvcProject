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

namespace WebUI.Controllers
{
    public class HeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        HeadingValidator hv = new HeadingValidator();
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

         // GET: Heading
        public ActionResult Index()
        {
            var values = hm.GetHeadings();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {

            List<SelectListItem> selects = (from x in cm.GetCategories()
                                            select new SelectListItem
                                            {

                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()

                                            }).ToList();

            List<SelectListItem> selectsWriter = (from x in wm.GetWriters()
                                                  select new SelectListItem
                                                  {

                                                      Text = x.WriterName+" "+ x.WriterSurname,
                                                      Value = x.WriterId.ToString()

                                                  }).ToList();




            ViewBag.vlc = selects;
            ViewBag.vlw = selectsWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {

            ValidationResult results = hv.Validate(heading);
            if (results.IsValid)
            {
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.Add(heading);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();
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
            return RedirectToAction("Index");
        }
       
        public ActionResult DeleteHeading(int id)
        {
            var results = hm.GetById(id);
            results.HeadingStatus = false;
            hm.Delete(results);
            return RedirectToAction("Index");
        }




    }
}