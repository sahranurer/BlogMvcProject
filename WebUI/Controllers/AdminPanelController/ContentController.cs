using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
       

        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetContents();//tüm listeyi başta çek
            if (!string.IsNullOrEmpty(p))
            {
                values = cm.GetContents(p);//veri girildiğinde bu kısım
                return View(values.ToList());
            }

            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var values = cm.GetListByHeadingId(id);
            return View(values);
        }


    }
}