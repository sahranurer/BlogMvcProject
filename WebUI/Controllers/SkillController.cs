using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class SkillController : Controller
    {

        TalentManager tm = new TalentManager(new EfTalentDal());

        public ActionResult Index()
        {
            var result = tm.GetTalents();
            return View(result);
        }
    }
}