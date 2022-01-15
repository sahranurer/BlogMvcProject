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
    public class AuthorizationController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var values = am.GetAdmins();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {

            //List<SelectListItem> selects = (from x in am.GetAdmins()
            //                                select new SelectListItem
            //                                {
            //                                    Text = x.AdminRole,
            //                                    Value = x.AdminID.ToString()
            //                                }).ToList();



            //ViewBag.vlc = selects;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            am.Add(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {

            //List<SelectListItem> selects = (from x in am.GetAdmins()
            //                                select new SelectListItem
            //                                {
            //                                    Text = x.AdminRole,
            //                                    Value = x.AdminID.ToString()
            //                                }).ToList();



            //ViewBag.vlc = selects;

            var results = am.GetById(id);
            return View(results);

        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.Update(p);
            return RedirectToAction("Index");
        }
    }
}