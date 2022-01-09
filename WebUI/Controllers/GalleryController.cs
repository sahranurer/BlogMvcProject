using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ımageFile = new ImageFileManager(new EfImageFileDal());

        // GET: Gallery
        public ActionResult Index()
        {
            var results = ımageFile.GetImageFiles();
            return View(results);
        }
    }
}