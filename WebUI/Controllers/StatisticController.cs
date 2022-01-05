using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class StatisticController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var results = _context.Categories.Count();
            ViewBag.CategoryCount = results;


            var baslik_sayisi = _context.Headings.Count(x => x.CategoryId == 15);
            ViewBag.HeadingsCategory = baslik_sayisi;

            var yazar_sayisi = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.WriterName = yazar_sayisi;

            var enfazla_baslik = _context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.HeadingsCategoryCount = enfazla_baslik;

            var status_true = _context.Categories.Count((x => x.CategoryStatus == true));
            var status_false = _context.Categories.Count(x => x.CategoryStatus == false);

            var sonuc = status_true - status_false;
            ViewBag.CategoryStatus = sonuc;
            






            return View();
        }
    }
}