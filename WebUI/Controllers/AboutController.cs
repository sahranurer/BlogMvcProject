using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {

        AboutManager am = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var results = am.GetAbouts();
            return View(results);
        }


        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        public ActionResult AddAbout(About about)
        {
            am.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult isActive(int id)
        {
            var value = am.GetById(id);
            if (value.isActive)
            {
                value.isActive = false;
            }
            else
            {
                value.isActive = true;
            }
            am.Update(value);
            return RedirectToAction("Index");
        }

    }


}
