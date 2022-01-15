using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers.AdminPanelController
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingPieChart()
        {
            return View();
        }

        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }

        public List<HeadingClass> HeadingList()
        {
            List<HeadingClass> headingCharts = new List<HeadingClass>();
            using (var context = new Context())
            {
                headingCharts = context.Headings.Select(c => new HeadingClass
                {
                    HeadingName = c.HeadingName,
                    HeadingCount = c.Contents.Count()
                }).ToList();
            }

            return headingCharts;
        }


        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName="Yazılım",
                CategoryCount=8
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return categoryClasses;
        }


    }
}