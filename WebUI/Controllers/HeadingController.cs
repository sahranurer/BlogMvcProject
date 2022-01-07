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
         // GET: Heading
        public ActionResult Index()
        {
            var values = hm.GetHeadings();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
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






    }
}