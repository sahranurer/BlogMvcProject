﻿using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //SHA1 sha = new SHA1CryptoServiceProvider();
            //string SifrelenecekVeri = admin.AdminPassword;
            //string SifrelenmisVeri = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(SifrelenecekVeri)));
            //admin.AdminPassword = SifrelenmisVeri;

            AdminManager am = new AdminManager(new EfAdminDal());
            var results = am.GetAdmins().FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (results!=null)
            {
                FormsAuthentication.SetAuthCookie(results.AdminUserName,false);
                Session["AdminUserName"] = results.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}