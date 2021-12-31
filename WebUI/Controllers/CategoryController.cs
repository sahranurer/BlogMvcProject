using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var result = cm.GetAll();
            return View(result);
        }
        public ActionResult AddCategory(Category c)
        {
            cm.Add(c);
            return RedirectToAction("GetCategoryList");

        }
    }
}