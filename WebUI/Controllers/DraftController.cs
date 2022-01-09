using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DraftController : Controller
    {
        DraftManager dm = new DraftManager(new EfDraftDal());
        // GET: Draft
        public ActionResult Index()
        {
            var results = dm.GetDrafts();
            return View(results);
        }
    }
}