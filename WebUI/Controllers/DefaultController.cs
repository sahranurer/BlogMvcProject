using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
   [AllowAnonymous]
    public class DefaultController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult DefaultHeadings()
        {
            var list = hm.GetHeadings();
            return View(list);
        }

        // GET: Default
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListByHeadingId(id);
            return PartialView(contentlist);
        }
    }
}